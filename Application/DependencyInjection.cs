using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection self)
        {
            self.AddMediatR(Assembly.GetExecutingAssembly());
            return self;
        }
    }
}
