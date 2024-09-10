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
    public class EquipmentEntityConfiguration : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Handbooks)
                .WithMany(h => h.Equipments)
                .UsingEntity<InstructionEquipmentEntity>();

            builder.HasMany(e => e.Orders)
               .WithMany(o => o.Equipments)
               .UsingEntity<OrderEquipmentEntity>();
        }
    }
}
