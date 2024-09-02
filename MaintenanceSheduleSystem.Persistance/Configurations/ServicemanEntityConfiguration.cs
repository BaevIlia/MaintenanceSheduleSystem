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
    public class ServicemanEntityConfiguration : IEntityTypeConfiguration<ServicemanEntity>
    {
        public void Configure(EntityTypeBuilder<ServicemanEntity> builder)
        {
            builder.HasKey(sm => sm.UserId);

            builder.HasOne(sm => sm.UserEntity)
                .WithOne(u => u.ServicemanEntity);
        }
    }
}
