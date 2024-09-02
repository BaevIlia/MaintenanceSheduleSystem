using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Persistance.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaintenanceSheduleSystem.Persistance.Configurations
{
    public class StorekeeperEntityConfiguration : IEntityTypeConfiguration<StorekeeperEntity>
    {
        public void Configure(EntityTypeBuilder<StorekeeperEntity> builder)
        {
            builder.HasKey(sk => sk.UserId);

            builder.HasOne(sk => sk.UserEntity)
                .WithOne(u => u.StorekeeperEntity);
        }
    }
}
