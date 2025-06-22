using ApplicationLayer.Contracts;
using InfrastructureLayer.Data;
using InfrastructureLayer.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace InfrastructureLayer.Config
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(config.GetConnectionString("DefaultConnection")));

             services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));  

            return services;
        }
    }
}
