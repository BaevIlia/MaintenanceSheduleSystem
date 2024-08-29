using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MaintenanceSheduleSystem.Persistance.Entities;

namespace MaintenanceSheduleSystem.Persistance.Configurations
{
    public class ServicemanConfiguration : IEntityTypeConfiguration<ServicemanEntity>
    {
        public void Configure(EntityTypeBuilder<ServicemanEntity> builder)
        {
            builder.HasKey(s => s.UserId);

            builder.HasOne(s => s.UserEntity)
                .WithOne(u => u.ServicemanEntity)
                .HasForeignKey<ServicemanEntity>(su => su.UserId);
        }
    }
}
