#region copyright
// CauseWeCan.Domain - NodeLinkSelection.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain.RouteSelection;

public class NodeLinkSelection:NodeSelection
{
    public string Link { get; set; } = default!;
}