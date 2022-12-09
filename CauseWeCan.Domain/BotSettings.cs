#region copyright
// CauseWeCan.Domain - BotSettings.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

using CauseWeCan.Domain.RouteSelection;

namespace CauseWeCan.Domain;

public class BotSettings
{
    public NodeSelection StartSelection { get; set; }
}