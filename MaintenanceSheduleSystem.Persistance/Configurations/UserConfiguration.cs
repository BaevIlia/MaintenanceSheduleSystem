using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MaintenanceSheduleSystem.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///TODO:
///сконфигурировать все сущности, занести предварительные данные, попробовать миграции
namespace MaintenanceSheduleSystem.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.AdministratorEntity)
                .WithOne(a => a.UserEntity)
                .HasForeignKey<AdministratorEntity>(ua => ua.UserId);
            builder.HasOne(u => u.PlannerEngineerEntity)
                .WithOne(p => p.UserEntity)
                .HasForeignKey<PlannerEngineerEntity>(up => up.UserId);

            builder.HasOne(u => u.ServicemanEntity)
                .WithOne(s => s.UserEntity)
                .HasForeignKey<ServicemanEntity>(us => us.UserId);
        }
    }
}
