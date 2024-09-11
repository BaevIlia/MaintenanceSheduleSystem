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
            var redisConfiguration = configuration.GetSection("Redis");
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProviderService, JwtProviderService>();
            services.AddScoped<ICacheService, CacheService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConfiguration["Host"];
            });
          
            return services;
        }
    }
}
