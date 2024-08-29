using MaintenanceSheduleSystem.Persistance;
using Microsoft.EntityFrameworkCore;
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
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"), b=>b.MigrationsAssembly("MaintenanceSheduleSystem.Persistance"));
            });

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
