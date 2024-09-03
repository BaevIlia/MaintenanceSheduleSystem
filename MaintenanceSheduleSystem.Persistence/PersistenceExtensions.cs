using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence
            (
                this IServiceCollection services,
                IConfiguration configuration
            ) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"), b => b.MigrationsAssembly("MaintenanceSheduleSystem.Persistence"));
            });
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
