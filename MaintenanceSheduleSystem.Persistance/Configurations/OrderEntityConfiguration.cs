using MaintenanceSheduleSystem.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.Id);


            builder.HasOne(o => o.Serviceman).
                WithMany(sm => sm.Orders)
                .HasForeignKey(o => o.Id);

            builder.HasOne(o => o.MachineArea)
                .WithMany(ma => ma.Orders)
                .HasForeignKey(a => a.AreaId);

            builder.HasMany(o => o.Equipments)
                .WithMany(e => e.Orders)
                .UsingEntity<OrderEquipmentList>();
        }
    }
}
