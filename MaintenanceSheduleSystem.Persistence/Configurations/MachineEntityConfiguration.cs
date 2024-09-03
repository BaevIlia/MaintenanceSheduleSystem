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

            builder.HasMany(m => m.Areas)
                .WithOne(a => a.Machine);
                
        }
    }
}
