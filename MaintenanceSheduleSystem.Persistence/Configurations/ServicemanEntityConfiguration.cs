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
    public class ServicemanEntityConfiguration : IEntityTypeConfiguration<ServicemanEntity>
    {
        public void Configure(EntityTypeBuilder<ServicemanEntity> builder)
        {
            builder.HasMany(sm => sm.Orders)
                .WithOne(o => o.Serviceman);
        }
    }
}
