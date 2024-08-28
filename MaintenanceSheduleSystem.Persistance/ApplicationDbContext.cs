using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
