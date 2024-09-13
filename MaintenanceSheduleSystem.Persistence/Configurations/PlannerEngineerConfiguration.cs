using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Configurations
{
    public class PlannerEngineerConfiguration : IEntityTypeConfiguration<PlannerEngineerEntity>
    {
        public void Configure(EntityTypeBuilder<PlannerEngineerEntity> builder)
        {
            builder.HasMany(pl => pl.Orders)
                .WithOne(o => o.PlannerEngineer);


            builder.HasData(
                new PlannerEngineerEntity
                {
                    Id = Guid.Parse("a69b942d-6024-4cb9-99ab-fdb813dda151"),
                    FullName = "Test, Test, Planner",
                    Email = "testPlanner@domain.ru",
                    Title = "TestTitle",
                    HashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("1234"),
                    Role = Core.Enums.Roles.Planner,
                    IsSacked = false,
                    
                });
        }
    }
}
