using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class Administrator : User
    {
        private Administrator(Guid id, string email, string hashedPassword, FullName fullName, string role, string ownAcceptKey) : base(id, email, hashedPassword, fullName, role)
        {
            OwnAcceptKey = ownAcceptKey;
        }

        public static Administrator Create(Guid id, string email, string hashedPassword, FullName fullName,  string ownAcceptKey)
        {
            return new Administrator(id, email, hashedPassword, fullName, role: "Администратор", ownAcceptKey);
        }
        public string OwnAcceptKey { get; set; } = string.Empty;
    }
}
