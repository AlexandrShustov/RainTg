using Application.Updates.Notifications;
using MediatR;
using Telegram.Bot.Types;

namespace Application.Updates.NotificationHandlers.UpdateReceived.Abstract
{
    public abstract class BaseUpdateHandler : INotificationHandler<UpdateReceivedNotification>
    {
        public Task Handle(UpdateReceivedNotification notification, CancellationToken cancellationToken)
        {
            if (ShouldHandle(notification!.Update!))
                return HandleUpdate(notification!.Update!, cancellationToken);

            return Task.CompletedTask;
        }

        protected abstract bool ShouldHandle(Update update);
        protected abstract Task HandleUpdate(Update update, CancellationToken cancellationToken);
    }
}
