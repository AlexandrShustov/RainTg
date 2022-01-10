using Telegram.Bot.Types;

namespace Application.Common.Interfaces
{
    public interface IBotService
    {
        Task StartReceivingUpdates();
        Task StopReceivingUpdates();

        Task Send(string message, long to);
    }
}
