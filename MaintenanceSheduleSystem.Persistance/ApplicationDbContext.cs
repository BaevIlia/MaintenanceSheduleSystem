using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Persistance.Entities;

namespace MaintenanceSheduleSystem.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<InstrumentEntity> Instruments { get; set; }
        public DbSet<MachineEntity> Machines { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PlannerEntity> Planners { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<SparePartEntity> SpareParts { get; set; }
        public DbSet<ServicesOrdersEntity> ServicesOrders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
