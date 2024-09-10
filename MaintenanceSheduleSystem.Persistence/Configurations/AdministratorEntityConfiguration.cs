
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
        private readonly IPasswordHasher _passwordHasher;
        public AdministratorEntityConfiguration(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Configure(EntityTypeBuilder<AdministratorEntity> builder)
        {
            builder.HasData(
                new AdministratorEntity()
                {
                    Id = Guid.NewGuid(),
                    FullName = "admin",
                    Email = "test@domain.ru",
                    HashedPassword = _passwordHasher.Generate("1234"),
                    IsSacked = false,
                    Role = Core.Enums.Roles.Admin,
                    SigningKey = string.Empty,

                });
        }
    }
}
