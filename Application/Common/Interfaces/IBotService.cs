namespace Application.Common.Interfaces
{
    public interface IBotService
    {
        Task StartReceivingUpdates();
        Task StopReceivingUpdates();
    }
}
