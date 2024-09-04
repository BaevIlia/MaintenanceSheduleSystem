using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public abstract class User
    {
        protected User(Guid id, string email, string hashedPassword, FullName fullName, Roles role)
        {
            Id = id;
            Email = email;
            HashedPassword = hashedPassword;
            FullName = fullName;
            Role = role;
        }

        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; }= string.Empty;
        public Roles Role { get; set; }
        public FullName FullName { get; set; }

        
    }
}
