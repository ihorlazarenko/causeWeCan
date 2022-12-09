#region copyright
// CauseWeCan.Domain - NodeMenuSelection.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain.RouteSelection;

public class NodeMenuSelection:NodeSelection
{
    public IList<NodeSelection> Nodes { get; } = new List<NodeSelection>();
}