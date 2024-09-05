using MaintenanceSheduleSystem.Persistence;
using MaintenanceSheduleSystem.Application;
using MaintenanceSheduleSystem.Infrastructure;
using MaintenanceSheduleSystem.API.Extensions;
using MaintenanceSheduleSystem.Infrastructure.OutsideServiceOptions;
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
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            builder.Services.AddApiAuthentication(builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
