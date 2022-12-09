using CauseWeCan.Configuration;
using CauseWeCan.Services;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);
var botConfig = builder.Configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
builder.Services.AddHostedService<SetupWebHookService>();
builder.Services.AddHttpClient("tgwebhook")
    .AddTypedClient<ITelegramBotClient>(httpClient => new TelegramBotClient(
        new TelegramBotClientOptions(botConfig.BotToken,botConfig.TelegramServer), httpClient));
builder.Services.AddScoped<HandleUpdateService>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.ConfigureStartSelection();

var app = builder.Build();

app.UseRouting();
app.UseCors();

app.UseEndpoints(endpoints =>
{
    // Configure custom endpoint per Telegram API recommendations:
    // https://core.telegram.org/bots/api#setwebhook
    // If you'd like to make sure that the Webhook request comes from Telegram, we recommend
    // using a secret path in the URL, e.g. https://www.example.com/<token>.
    // Since nobody else knows your bot's token, you can be pretty sure it's us.
    var token = botConfig.BotToken;
    endpoints.MapControllerRoute(name: "tgwebhook",
        pattern: $"bot/{token}",
        new { controller = "Webhook", action = "Post" });
    endpoints.MapControllers();
});

app.Run();
