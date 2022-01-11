using Telegram.Bot.Types;

namespace Application.Common.Interfaces
{
    public interface IExceptionHandler
    {
        bool CanHandle(Exception ex, Update update);
        Task Handle(Exception ex, Update update);
    }
}
