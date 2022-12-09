#region copyright
// CauseWeCan - HandleUpdateService.cs
// Copyright (c) 2022 All Rights Reserved
// Datascope, Ihor Lazarenko
// ihor.lazarenko@datascopeplc.com
#endregion

using CauseWeCan.Telegram;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace CauseWeCan.Services;

public class HandleUpdateService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<HandleUpdateService> _logger;
    private readonly DriveNodesSelection _nodesSelectionDriver;

    public HandleUpdateService(ITelegramBotClient botClient, ILogger<HandleUpdateService> logger, DriveNodesSelection nodesSelectionDriver)
    {
        _botClient = botClient;
        _logger = logger;
        _nodesSelectionDriver = nodesSelectionDriver;
    }

    public async Task EchoAsync(Update update)
    {
        var handler = update.Type switch
        {
            // UpdateType.Unknown:
            // UpdateType.ChannelPost:
            // UpdateType.EditedChannelPost:
            // UpdateType.ShippingQuery:
            // UpdateType.PreCheckoutQuery:
            // UpdateType.Poll:
            UpdateType.Message => BotOnMessageReceived(update.Message!),
            //UpdateType.EditedMessage => BotOnMessageReceived(update.EditedMessage!),
            //UpdateType.CallbackQuery => BotOnCallbackQueryReceived(update.CallbackQuery!),
            //UpdateType.InlineQuery => BotOnInlineQueryReceived(update.InlineQuery!),
            //UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(update.ChosenInlineResult!),
            _ => UnknownUpdateHandlerAsync(update)
        };

        try
        {
            await handler;
        }
#pragma warning disable CA1031
        catch (Exception exception)
#pragma warning restore CA1031
        {
            await HandleErrorAsync(exception);
        }
    }

    private async Task BotOnMessageReceived(Message message)
    {
        if (message.Text.StartsWith("/newuser"))
        {
            await _nodesSelectionDriver.StartRoute(message.Chat.Id);
        }
        //if (message.From?.IsBot!=false) return;
        //var chatAdministrators = await _botClient.GetChatAdministratorsAsync(message.Chat.Id);
        //if (chatAdministrators.Any(c => c.User.Id == message.From.Id))
        //{
        //    await _botClient.SendTextMessageAsync(message.Chat.Id, $"echo: {message.Text}");
        //}
        //else
        //{
        //    await _botClient.SendTextMessageAsync(message.Chat.Id, $"{message.From.FirstName} {message.From.LastName},you are not admin");
        //}
    }

    private Task UnknownUpdateHandlerAsync(Update update)
    {
        _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }

    public Task HandleErrorAsync(Exception exception)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        _logger.LogInformation("HandleError: {ErrorMessage}", errorMessage);
        return Task.CompletedTask;
    }
}