using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public Roles Role { get; set; }
        public AdministratorEntity? AdministratorEntity { get; set; }
        public PlannerEngineerEntity? PlannerEngineerEntity { get; set; }
        public ServicemanEntity? ServicemanEntity { get; set; }

        
        
    }
}
