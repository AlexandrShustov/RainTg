using Application.Common.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Raindrops;
using Infrastructure.Security;
using Infrastructure.TelegramBot;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection self)
        {
            self.AddSingleton<IBotService, BotService>();
            //self.AddScoped<IRaindropService, RaindropService>();
            self.AddHttpClient<IRaindropService, RaindropService>();
            self.AddSingleton<IAuthTokenStorage, InMemoryAuthTokenStorage>();
            self.AddTransient<ICryptoService, CryptoService>();

            return self;
        }
    }
}
