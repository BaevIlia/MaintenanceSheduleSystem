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

            builder.HasMany(h => h.Equipments)
                .WithMany(eq => eq.Instructions)
                .UsingEntity<InstructionEquipmentEntity>();

            builder.HasData(
                new InstructionEntity
                {
                    Id = Guid.Parse("c1529764-27da-4207-9d7d-5981d9ba6b34"),
                    AreaId = Guid.Parse("f6cd323f-9c21-4dc6-8533-493a89d6459a"),
                    TypeOfWork = Core.Enums.TypeOfWork.Maintenance,
                    Instructions = "TestDesc",
                });
            
        }
    }
}
