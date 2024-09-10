using MaintenanceSheduleSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<UserBaseService>();
            services.AddScoped<AdministratorService>();
            return services;
        }
    }
}
