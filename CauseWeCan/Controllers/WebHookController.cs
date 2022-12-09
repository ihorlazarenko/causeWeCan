#region copyright
// CauseWeCan - WebHookController.cs
// Copyright (c) 2022 All Rights Reserved
// Datascope, Ihor Lazarenko
// ihor.lazarenko@datascopeplc.com
#endregion

using CauseWeCan.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace CauseWeCan.Controllers;

public class WebHookController:Controller
{
    [HttpPost]
    public async Task<IActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
        [FromBody] Update update)
    {
        await handleUpdateService.EchoAsync(update);
        return Ok();
    }
}