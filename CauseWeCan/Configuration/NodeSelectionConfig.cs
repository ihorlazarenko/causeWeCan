#region copyright
// CauseWeCan - StartSelectionConfig.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Configuration;

public class NodeSelectionConfig
{
    public string Type { get; set; } = "menu";
    public string Caption { get; set; } = string.Empty;
    public string? Link { get; set; }
    public IList<NodeSelectionConfig>? Nodes { get; set; }
}