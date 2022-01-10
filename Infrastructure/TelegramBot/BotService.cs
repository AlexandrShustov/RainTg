using Application.Common.Interfaces;
using Domain.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;

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

        public async Task StartReceivingUpdates() => await _client.SetWebhookAsync(_options.WebhookUrl);
        public async Task StopReceivingUpdates() => await _client.DeleteWebhookAsync(dropPendingUpdates: false);
    }
}
