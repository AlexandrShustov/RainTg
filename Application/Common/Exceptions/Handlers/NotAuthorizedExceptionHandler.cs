using Application.Common.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.Common.Exceptions.Handlers
{
    public class NotAuthorizedExceptionHandler : IExceptionHandler
    {
        private readonly IBotService _bot;

        public NotAuthorizedExceptionHandler(IBotService bot) =>
            _bot = bot;

        public bool CanHandle(Exception ex, Update update) =>
            ex is NotAuthorizedException &&
            update?.Type == UpdateType.Message &&
            update?.Message?.Chat != null;

        public async Task Handle(Exception ex, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            await _bot.Send("Raindrop authorization required. Please, use /authorize command.", chatId);
        }
    }
}
