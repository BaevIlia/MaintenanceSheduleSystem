using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public abstract class User
    {
        protected User(Guid id, string email, string hashedPassword, FullName fullName, string role)
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
        public string Role { get; set; } = string.Empty;
        public FullName FullName { get; set; }
    }
}
