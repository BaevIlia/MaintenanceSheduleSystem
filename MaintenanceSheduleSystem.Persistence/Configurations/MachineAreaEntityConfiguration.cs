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
    public class MachineAreaEntityConfiguration : IEntityTypeConfiguration<MachineAreaEntity>
    {
        public void Configure(EntityTypeBuilder<MachineAreaEntity> builder)
        {
            builder.HasKey(ma => ma.Id);

            builder.HasOne(m => m.Machine)
                .WithMany(ma => ma.MachineAreas)
                .HasForeignKey(ma => ma.MachineId);

            builder.HasMany(ma => ma.Instructions)
                .WithOne(h => h.MachineArea);

            builder.HasMany(ma => ma.Orders)
                .WithOne(o => o.MachineArea);

            builder.HasData(
                new MachineAreaEntity
                {

                    Id = Guid.Parse("f6cd323f-9c21-4dc6-8533-493a89d6459a"),
                    MachineId = Guid.Parse("baf57b0d-d6dd-481e-8b7b-ba03f57dab9c"),
                    AreaName = "TestArea",
                    AreaDescription = "TestDesc"

                });

        }
    }
}
