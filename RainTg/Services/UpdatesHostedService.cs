using Application.Common.Interfaces;

namespace Web.Services
{
    public class UpdatesHostedService : IHostedService
    {
        private readonly IBotService _bot;

        public UpdatesHostedService(IBotService bot) => 
            _bot = bot;

        public async Task StartAsync(CancellationToken cancellationToken) => 
            await _bot.StartReceivingUpdates();

        public async Task StopAsync(CancellationToken cancellationToken) => 
            await _bot.StopReceivingUpdates();
    }
}
