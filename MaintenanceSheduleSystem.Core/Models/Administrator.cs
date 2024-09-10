using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class Administrator : User
    {
        private Administrator(Guid id, string email, string hashedPassword, FullName fullName, Roles role, string signingKey) : base(id, email, hashedPassword, fullName, role)
        {
            SigningKey = signingKey;
        }

        public static Administrator Create(Guid id, string email, string hashedPassword, FullName fullName,  string signingKey)
        {
            return new Administrator(id, email, hashedPassword, fullName, Roles.Admin, signingKey);
        }
        public string SigningKey { get; set; } = string.Empty;
    }
}
