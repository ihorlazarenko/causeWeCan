#region copyright
// CauseWeCan.Telegram - DriveNodesSelection.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

using CauseWeCan.Domain.RouteSelection;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace CauseWeCan.Telegram;

public class DriveNodesSelection
{

    public DriveNodesSelection(ITelegramBotClient botClient,IList<NodeSelection> nodes)
    {
        _nodes = nodes;
        _botClient = botClient;
    }

    public async Task StartRoute(long chatId)
    {
        await _botClient.SendTextMessageAsync(chatId, "дайте відповідь на наші питання", replyMarkup:new ReplyKeyboardMarkup(
            _nodes.Chunk(MaxButtonsInRow).Select(
                nodes=>
                    nodes.Select(n=>new KeyboardButton(n.Caption))
                )
            ));
    }

    private const int MaxButtonsInRow = 4;

    private readonly IList<NodeSelection> _nodes;
    private readonly ITelegramBotClient _botClient;

}