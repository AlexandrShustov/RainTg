using Application.Common.Interfaces;
using Infrastructure.TelegramBot;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection self)
        {
            self.AddSingleton<IBotService, BotService>();
            return self;
        }
    }
}
