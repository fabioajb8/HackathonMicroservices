using Hackathon.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
            => services.AddScoped<IServiceManager, ServiceManager>();
    }
}
