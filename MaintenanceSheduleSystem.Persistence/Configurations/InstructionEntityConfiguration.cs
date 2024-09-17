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
    public class InstructionEntityConfiguration : IEntityTypeConfiguration<InstructionEntity>
    {
        public void Configure(EntityTypeBuilder<InstructionEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.MachineArea)
                .WithMany(ma => ma.Instructions)
                .HasForeignKey(h => h.AreaId);

            builder.HasMany(i => i.InstructionEquipmentLists)
                .WithOne(il => il.Instruction)
                .HasForeignKey(il => il.InstructionId);

            
        }
    }
}
