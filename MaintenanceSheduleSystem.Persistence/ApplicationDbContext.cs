using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Persistence.Configurations;
using MaintenanceSheduleSystem.Persistence.Entities;
using MaintenanceSheduleSystem.Core.Interfaces;


namespace MaintenanceSheduleSystem.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

    
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdministratorEntity> Administrators { get; set; }
        public DbSet<PlannerEngineerEntity> PlannerEngineers { get; set; }
        public DbSet<ServicemanEntity> Servicemen { get; set; }
        public DbSet<EquipmentEntity> Equipments { get; set; }
        public DbSet<InstructionEntity> Instructions { get; set; }
        public DbSet<MachineEntity> Machines { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<MachineAreaEntity> MachineAreas { get; set; }
        public DbSet<InstructionEquipmentListEntity> InstructionEquipment { get; set; }
        public DbSet<OrderEquipmentListEntity> OrderEquipment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
            modelBuilder.ApplyConfiguration(new EquipmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstructionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MachineAreaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MachineEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstructionEquipmentListConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEquipmentListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdministratorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PlannerEngineerConfiguration());
            modelBuilder.ApplyConfiguration(new ServicemanEntityConfiguration());

        }
    }
}
