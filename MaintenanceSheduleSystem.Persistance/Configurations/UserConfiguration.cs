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

            builder.ToTable("Users")
            .SplitToTable(
                "Administrators",
                tableBuilder =>
                {
                    tableBuilder.Property(u => u.Id).HasColumnName("UserId");
                    tableBuilder.Property(u => u.FullName);
                    tableBuilder.Property(u => u.Email);
                    tableBuilder.Property(u => u.HashedPassword);
                    tableBuilder.Property(u => u.OwnAcceptKey);
                })
            .SplitToTable(
                "Services",
                tableBuilder =>
                {
                    tableBuilder.Property(u => u.Id).HasColumnName("UserId");
                    tableBuilder.Property(u => u.FullName);
                    tableBuilder.Property(u => u.Email);
                    tableBuilder.Property(u => u.HashedPassword);
                });
        }
    }
}
