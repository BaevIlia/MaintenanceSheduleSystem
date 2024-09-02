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
    public class AdministratorEntityConfiguration : IEntityTypeConfiguration<AdministratorEntity>
    {
        public void Configure(EntityTypeBuilder<AdministratorEntity> builder)
        {
            builder.HasKey(a => a.UserId);

            builder.HasOne(a => a.UserEntity)
                .WithOne(u => u.AdministratorEntity);
        }
    }
}
