using Application.Common.Interfaces;
using Domain.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Infrastructure.TelegramBot
{
    public class BotService : IBotService
    {
        private readonly TelegramBotClient _client;
        private readonly TelegramOptions _options;

        public BotService(IOptions<TelegramOptions> options)
        {
            _options = options.Value;
            _client = new TelegramBotClient(_options.Token);
        }

        public Task Send(string message, long to)
        {
            return _client.SendTextMessageAsync(to, message);
        }

        public async Task StartReceivingUpdates() =>
            await _client.SetWebhookAsync($"{_options.WebhookUrl}/bot/{_options.Token}");

        public async Task StopReceivingUpdates() => 
            await _client.DeleteWebhookAsync(dropPendingUpdates: false);
    }
}
