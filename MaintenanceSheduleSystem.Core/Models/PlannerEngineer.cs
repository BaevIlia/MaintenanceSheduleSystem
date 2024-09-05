using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class PlannerEngineer : User
    {
        private PlannerEngineer(Guid id, string email, string hashedPassword, FullName fullName, Roles role, string title) : base(id, email, hashedPassword, fullName, role)
        {
        }

        public static PlannerEngineer Create(Guid id, string email, string hashedPassword, FullName fullName, string title) 
        {
            return new PlannerEngineer(id, email, hashedPassword, fullName,  Roles.Planner, title);
        }

        public string Title { get; set; } = string.Empty;
    }
}
