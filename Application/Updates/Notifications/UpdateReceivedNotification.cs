using MediatR;
using Telegram.Bot.Types;

namespace Application.Updates.Notifications
{
    public class UpdateReceivedNotification : INotification
    {
        public Update? Update { get; set; }
    }
}
