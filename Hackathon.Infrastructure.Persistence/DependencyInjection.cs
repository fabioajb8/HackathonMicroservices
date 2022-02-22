using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddDbContext<RepositoryContext>(options 
                => options.UseSqlServer(configuration.GetConnectionString("sqlconnection"), b
                => b.MigrationsAssembly("Hackathon.Persistence")));

            return services;
        }
    }
}