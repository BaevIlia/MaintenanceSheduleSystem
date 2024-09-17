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
    public class InstructionEquipmentListConfiguration : IEntityTypeConfiguration<InstructionEquipmentListEntity>
    {
        public void Configure(EntityTypeBuilder<InstructionEquipmentListEntity> builder)
        {
            builder.HasKey(il => new {il.InstructionId, il.EquipmentId });
                
        }
    }
}
