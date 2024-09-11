using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Infrastructure.LogicServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.StackExchangeRedis;
namespace MaintenanceSheduleSystem.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProviderService, JwtProviderService>();
            services.AddScoped<ICacheService, CacheService>();

      
          
            return services;
        }
    }
}
