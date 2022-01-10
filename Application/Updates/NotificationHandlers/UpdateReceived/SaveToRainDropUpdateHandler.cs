using Application.Common.Interfaces;
using Application.Updates.NotificationHandlers.UpdateReceived.Abstract;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.Updates.NotificationHandlers.UpdateReceived
{
    public class SaveToRainDropUpdateHandler : BaseUpdateHandler
    {
        private readonly IBotService _bot;

        public SaveToRainDropUpdateHandler(IBotService bot) => _bot = bot;

        protected override bool ShouldHandle(Update update) => update.Type == UpdateType.Message;

        protected override async Task HandleUpdate(Update update, CancellationToken cancellationToken)
        {
            var chatId = update!.Message!.Chat.Id;
            await _bot.Send("Saving to Raindrop...", chatId);
        }
    }
}
