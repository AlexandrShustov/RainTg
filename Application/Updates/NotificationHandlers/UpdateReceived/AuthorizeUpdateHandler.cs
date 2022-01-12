using Application.Common.Interfaces;
using Application.Updates.NotificationHandlers.UpdateReceived.Abstract;
using Domain.Options;
using Microsoft.Extensions.Options;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.Updates.NotificationHandlers.UpdateReceived
{
    internal class AuthorizeUpdateHandler : BaseUpdateHandler
    {
        private readonly IBotService _bot;
        private readonly IOptions<RaindropOptions> _options;

        public AuthorizeUpdateHandler(IBotService bot, IOptions<RaindropOptions> options, IEnumerable<IExceptionHandler> handlers) : base(handlers)
        {
            _bot = bot;
            _options = options;
        }

        protected override async Task HandleUpdate(Update update, CancellationToken cancellationToken)
        {
            var chatId = update.Message.Chat.Id;

            var redirectUrl = _options.Value.RedirectUrl + $"/{chatId}";
            redirectUrl = HttpUtility.UrlEncode(redirectUrl);

            var authUrl = string.Format(_options.Value.AuthUrl, redirectUrl);

            await _bot.Send($"Auth required, please, follow the link - {authUrl}", chatId);
        }

        protected override bool ShouldHandle(Update update) =>
            update.Type == UpdateType.Message && (update?.Message?.Text?.Contains("/authorize") ?? false);
    }
}
