using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Core.Enums;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class Serviceman : User
    {
        private Serviceman(Guid id, string email, string hashedPassword, FullName fullName, Roles role, List<WorkOrder> workOrders) : base(id, email, hashedPassword, fullName, role)
        {
            WorkOrders = workOrders;
        }

        public static Serviceman Create(Guid id, string email, string hashedPassword, FullName fullName, List<WorkOrder> workOrders) 
        {
            return new Serviceman(id, email, hashedPassword, fullName, role: Roles.Service, workOrders);
        }

        public List<WorkOrder> WorkOrders { get; set; }


    }
}
