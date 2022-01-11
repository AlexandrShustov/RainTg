using Application.Common.Interfaces;
using Application.Updates.NotificationHandlers.UpdateReceived.Abstract;
using Domain.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Application.Updates.NotificationHandlers.UpdateReceived
{
    internal class AuthorizeUpdateHandler : BaseUpdateHandler
    {
        private readonly IBotService _bot;
        private readonly IOptions<TelegramOptions> _options;

        public AuthorizeUpdateHandler(IBotService bot, IOptions<TelegramOptions> options, IEnumerable<IExceptionHandler> handlers) : base(handlers)
        {
            _bot = bot;
            _options = options;
        }

        protected override async Task HandleUpdate(Update update, CancellationToken cancellationToken)
        {
            await _bot.Send("Not implemented", update.Message.Chat.Id);
        }

        protected override bool ShouldHandle(Update update) =>
            update.Type == UpdateType.Message && (update?.Message?.Text?.Contains("/authorize") ?? false);
    }
}
