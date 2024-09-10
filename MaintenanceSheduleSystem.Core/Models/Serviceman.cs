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
        private Serviceman(Guid id, string email, string hashedPassword, FullName fullName, Roles role) : base(id, email, hashedPassword, fullName, role)
        {

        }

        public static Serviceman Create(Guid id, string email, string hashedPassword, FullName fullName) 
        {
            return new Serviceman(id, email, hashedPassword, fullName, role: Roles.Service);
        }




    }
}
