using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaintenanceSheduleSystem.Persistence.Configurations
{
    public class EquipmentEntityConfiguration : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Instructions)
                .WithMany(h => h.Equipments)
                .UsingEntity<InstructionEquipmentEntity>(
                l => l.HasOne<InstructionEntity>().WithMany().HasForeignKey(i => i.InstructionId),
                r=>r.HasOne<EquipmentEntity>().WithMany().HasForeignKey(e=>e.EquipmentId));

            builder.HasMany(e => e.Orders)
               .WithMany(o => o.Equipments)
               .UsingEntity<OrderEquipmentEntity>(
                l=>l.HasOne<OrderEntity>().WithMany().HasForeignKey(o=>o.OrderId),
                r=>r.HasOne<EquipmentEntity>().WithMany().HasForeignKey(e=>e.EquipmentId));

            builder.HasData(
                new EquipmentEntity {Id= Guid.Parse("f84c16d1-5373-46b1-8340-db980e94bf32"), Article = "12345", Name = "TestSpare", StoragePlace = "A1",Type = EquipmentTypes.SparePart, Count = 10,IsInStock = true },
                new EquipmentEntity {Id= Guid.Parse("1a1db12d-0106-4d06-afc9-8cea47ff876e"), Article = "3421", Name = "TestInstrument", StoragePlace = "A2",Type = EquipmentTypes.Instrument, Count = 2, IsInStock = true }

                );
        }
    }
}
