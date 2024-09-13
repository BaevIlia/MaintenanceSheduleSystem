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


            builder.HasData(
                new OrderEquipmentEntity
                {
                    OrderId = Guid.Parse("12055903-390d-42e7-b98f-16dfe77f053e"),
                    EquipmentId = Guid.Parse("f84c16d1-5373-46b1-8340-db980e94bf32"),
                },
                new OrderEquipmentEntity
                {
                    OrderId = Guid.Parse("12055903-390d-42e7-b98f-16dfe77f053e"),
                    EquipmentId = Guid.Parse("1a1db12d-0106-4d06-afc9-8cea47ff876e"),
                }
                );
        }
    }
}
