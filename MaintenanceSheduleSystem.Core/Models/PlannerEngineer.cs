using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class PlannerEngineer : User
    {
        private PlannerEngineer(Guid id, string email, string hashedPassword, FullName fullName, string role) : base(id, email, hashedPassword, fullName, role)
        {
        }

        public static PlannerEngineer Create(Guid id, string email, string hashedPassword, FullName fullName) 
        {
            return new PlannerEngineer(id, email, hashedPassword, fullName,  role: "Инженер");
        }

        
    }
}
