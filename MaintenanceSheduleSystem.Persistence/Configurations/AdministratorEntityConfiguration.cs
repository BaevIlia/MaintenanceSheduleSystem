
using BCrypt.Net;
using MaintenanceSheduleSystem.Core.Interfaces;
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
    public class AdministratorEntityConfiguration : IEntityTypeConfiguration<AdministratorEntity>
    {

        public void Configure(EntityTypeBuilder<AdministratorEntity> builder)
        {
            builder.HasData(
                new AdministratorEntity()
                {
                    Id = Guid.Parse("5ac264b6-7490-48b2-93ca-63204fb0bc7b"),
                    FullName = "surname name lastname",
                    Email = "test@domain.ru",
                    HashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("1234"),
                    IsSacked = false,
                    Role = Core.Enums.Roles.Admin,
                    SigningKey = string.Empty,

                });
        }
    }
}
