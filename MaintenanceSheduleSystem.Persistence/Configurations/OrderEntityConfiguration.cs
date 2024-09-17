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
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.Id);


            builder.HasOne(o => o.Serviceman).
                WithMany(sm => sm.Orders)
                .HasForeignKey(o => o.ServicemanId);

            builder.HasOne(o=>o.PlannerEngineer)
                .WithMany(pl=>pl.Orders)
                .HasForeignKey(o => o.PlannerEngineerId);

            builder.HasOne(o => o.MachineArea)
                .WithMany(ma => ma.Orders)
                .HasForeignKey(a => a.AreaId);

            builder.HasMany(o => o.OrderEquipmentList)
                .WithOne(el => el.Order)
                .HasForeignKey(el => el.OrderId);

            builder.HasData(
                new OrderEntity
                {
                    Id = Guid.Parse("12055903-390d-42e7-b98f-16dfe77f053e"),
                    MachineId = Guid.Parse("baf57b0d-d6dd-481e-8b7b-ba03f57dab9c"),
                    AreaId = Guid.Parse("f6cd323f-9c21-4dc6-8533-493a89d6459a"),
                    Name = "TestOrder",
                    Description = "TestOrderDesc",
                    PlannerEngineerId = Guid.Parse("a69b942d-6024-4cb9-99ab-fdb813dda151"),
                    ServicemanId = Guid.Parse("69fc24dd-44ed-460e-b183-36da93374664"),
                    CreatedDateTime = DateTime.UtcNow,
                    TypeOfWork = Core.Enums.TypeOfWork.Maintenance



                });
           
        }
    }
}
