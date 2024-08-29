using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MaintenanceSheduleSystem.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Configurations
{
    public class PlannerEngineerConfiguration : IEntityTypeConfiguration<PlannerEngineerEntity>
    {
        public void Configure(EntityTypeBuilder<PlannerEngineerEntity> builder)
        {
            builder.HasKey(p => p.UserId);

            builder.HasOne(p => p.UserEntity)
                .WithOne(u => u.PlannerEngineerEntity)
                .HasForeignKey<PlannerEngineerEntity>(pu => pu.UserId);

        }
    }
}
