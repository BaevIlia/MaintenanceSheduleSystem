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
    public class OrderEquipmentEntityConfiguration : IEntityTypeConfiguration<OrderEquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEquipmentEntity> builder)
        {
            builder.HasKey(o => new { o.OrderId, o.EquipmentId });
        }
    }
}
