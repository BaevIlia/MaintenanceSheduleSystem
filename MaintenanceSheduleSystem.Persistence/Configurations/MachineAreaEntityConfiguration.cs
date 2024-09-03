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
                .WithMany(ma => ma.Areas)
                .HasForeignKey(ma => ma.MachineId);

            builder.HasMany(ma => ma.Handbooks)
                .WithOne(h => h.MachineArea);

            builder.HasMany(ma => ma.Orders)
                .WithOne(o => o.MachineArea);

        }
    }
}
