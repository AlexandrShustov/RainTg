using Application.Common.Interfaces;
using Application.Updates.Notifications;
using MediatR;
using Telegram.Bot.Types;

namespace Application.Updates.NotificationHandlers.UpdateReceived.Abstract
{
    public abstract class BaseUpdateHandler : INotificationHandler<UpdateReceivedNotification>
    {
        private readonly IEnumerable<IExceptionHandler> _handlers;

        public BaseUpdateHandler(IEnumerable<IExceptionHandler> handlers)
        {
            _handlers = handlers;
        }

        public async Task Handle(UpdateReceivedNotification notification, CancellationToken cancellationToken)
        {
            if (ShouldHandle(notification!.Update!))
            {
                try
                {
                    await HandleUpdate(notification!.Update!, cancellationToken);
                }
                catch (Exception ex)
                {
                    var handler = _handlers.FirstOrDefault(x => x.CanHandle(ex, notification.Update!));
                    if (handler != null)
                        await handler.Handle(ex, notification.Update!);
                    else
                        return;
                }
            }
        }

        protected abstract bool ShouldHandle(Update update);
        protected abstract Task HandleUpdate(Update update, CancellationToken cancellationToken);
    }
}
