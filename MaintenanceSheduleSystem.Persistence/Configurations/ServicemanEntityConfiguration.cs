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
    public class ServicemanEntityConfiguration : IEntityTypeConfiguration<ServicemanEntity>
    {
        public void Configure(EntityTypeBuilder<ServicemanEntity> builder)
        {
            builder.HasMany(sm => sm.Orders)
                .WithOne(o => o.Serviceman);

            builder.HasData(
                new ServicemanEntity
                {
                    Id = Guid.Parse("69fc24dd-44ed-460e-b183-36da93374664"),
                    FullName = "Test Test Serviceman",
                    Email = "testService@domain.ru",
                    HashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("1234"),
                    Role = Core.Enums.Roles.Service,
                    IsSacked = false
                });
        }
    }
}
