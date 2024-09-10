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
    public class InstructionEquipmentConfiguration : IEntityTypeConfiguration<InstructionEquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<InstructionEquipmentEntity> builder)
        {
            builder.HasKey(i => new { i.EquipmentId, i.HandbookId });
        }
    }
}
