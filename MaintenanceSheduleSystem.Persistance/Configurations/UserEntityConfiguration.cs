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
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.AdministratorEntity)
                .WithOne(a => a.UserEntity)
                .HasForeignKey<AdministratorConfiguration>(ua => ua.UserId);

            builder.HasOne(u => u.PlannerEngineerEntity)
                .WithOne(p => p.UserEntity)
                .HasForeignKey<PlannerEngineerConfiguration>(up => up.UserId);

            builder.HasOne(u => u.ServicemanEntity)
                .WithOne(s => s.UserEntity)
                .HasForeignKey<ServicemanEntity>(up => up.UserId);


            builder.HasOne(u => u.StorekeeperEntity)
                .WithOne(p => p.UserEntity)
                .HasForeignKey<PlannerEngineerConfiguration>(up => up.UserId);
        }
    }
}
