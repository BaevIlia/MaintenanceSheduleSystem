using MaintenanceSheduleSystem.Persistence;
using MaintenanceSheduleSystem.Application;
using MaintenanceSheduleSystem.Infrastructure;
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
            builder.Services.AddInfrastructure();


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
