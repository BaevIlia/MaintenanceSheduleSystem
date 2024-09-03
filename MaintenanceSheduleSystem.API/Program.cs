using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Infrastructure.Services;

using MaintenanceSheduleSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MaintenanceSheduleSystem.Persistence;
namespace MaintenanceSheduleSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.MapControllers();

            app.Run();
        }
    }
}
