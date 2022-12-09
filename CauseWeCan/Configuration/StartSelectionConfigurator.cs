#region copyright
// CauseWeCan - StartSelectionConfigurator.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

using System.Diagnostics;
using CauseWeCan.Configuration;
using CauseWeCan.Domain.RouteSelection;
using CauseWeCan.Telegram;
using Microsoft.AspNetCore.Mvc.Formatters;
using Telegram.Bot;

namespace CauseWeCan.Configuration;

public static class StartSelectionConfigurator
{

    public static void ConfigureStartSelection(this WebApplicationBuilder builder)
    {
        var nodeSelectionConfig = builder.Configuration.GetSection("StartSelection").Get<NodeSelectionConfig>();
        var startNode = CreateNodeSelector(nodeSelectionConfig);
            builder.Services.AddScoped((sp) =>
                startNode switch
                {
                    NodeMenuSelection menuNode=> new DriveNodesSelection(sp.GetService<ITelegramBotClient>()!, menuNode.Nodes),
                    _ => new DriveNodesSelection(sp.GetService<ITelegramBotClient>()!, new List<NodeSelection>() { startNode })
                }
            );
    }

    private static NodeSelection CreateNodeSelector(NodeSelectionConfig config)
    {
        return  (config.Type) switch {
            "menu"=>CreateNodeMenuSelection(config),
            "link"=>CreateNodeLinkSelection(config),
            _ => new NodeSelection()
        };
    }

    private static NodeMenuSelection CreateNodeMenuSelection(NodeSelectionConfig config)
    {
        var menuNode = new NodeMenuSelection()
        {
            Caption = config.Caption
        };
        foreach (var node in config.Nodes?.Select(CreateNodeSelector).ToArray() ?? Array.Empty<NodeSelection>())
        {
            menuNode.Nodes.Add(node);
        }
        return menuNode;
    }

    private static NodeLinkSelection CreateNodeLinkSelection(NodeSelectionConfig config)
    {
        return new NodeLinkSelection()
        {
            Caption = config.Caption,
            Link = config.Link!
        };
    }
}