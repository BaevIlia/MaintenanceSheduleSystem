using MaintenanceSheduleSystem.Core.Enums;
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
    public class MachineEntityConfiguration : IEntityTypeConfiguration<MachineEntity>
    {
        public void Configure(EntityTypeBuilder<MachineEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.MachineAreas)
                .WithOne(a => a.Machine);

            builder.HasData(
                new MachineEntity
                {
                    Id = Guid.Parse("baf57b0d-d6dd-481e-8b7b-ba03f57dab9c"),
                    Name = "TestLine",
                    SerialNumber = "123",
                  
                });
        }
    }
}
