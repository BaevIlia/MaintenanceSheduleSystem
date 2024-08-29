using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Persistance.Entities;
using MaintenanceSheduleSystem.Persistance.Configurations;

namespace MaintenanceSheduleSystem.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<InstrumentEntity> Instruments { get; set; }
        public DbSet<MachineEntity> Machines { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<SparePartsEntity> SpareParts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
        }
    }
}
