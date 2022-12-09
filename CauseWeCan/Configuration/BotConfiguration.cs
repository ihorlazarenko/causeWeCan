#region copyright
// CauseWeCan - BotConfiguration.cs
// Copyright (c) 2022 All Rights Reserved
// Datascope, Ihor Lazarenko
// ihor.lazarenko@datascopeplc.com
#endregion

namespace CauseWeCan.Configuration;

public class BotConfiguration
{
    public string BotToken { get; init; } = default!;
    public string HostAddress { get; init; } = default!;
    public string TelegramServer { get; init; } = default!;
}