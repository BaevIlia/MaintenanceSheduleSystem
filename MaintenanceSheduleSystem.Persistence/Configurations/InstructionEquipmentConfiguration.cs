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
            builder.HasKey(i => new { i.InstructionId, i.EquipmentId });

            builder.HasData(
                new InstructionEquipmentEntity
                {
                    InstructionId = Guid.Parse("c1529764-27da-4207-9d7d-5981d9ba6b34"),
                    EquipmentId = Guid.Parse("f84c16d1-5373-46b1-8340-db980e94bf32"),
                },
                new InstructionEquipmentEntity
                {
                InstructionId = Guid.Parse("c1529764-27da-4207-9d7d-5981d9ba6b34"),
                EquipmentId = Guid.Parse("1a1db12d-0106-4d06-afc9-8cea47ff876e"),
                });
        }
    }
}
