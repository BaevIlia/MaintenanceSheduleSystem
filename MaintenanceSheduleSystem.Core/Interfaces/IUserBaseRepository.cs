using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IUserBaseRepository
    {
        public Task<User> GetByEmail(string email);
        public Task<User> GetById(Guid id);
        public Task<bool> ChangePassword(User user, string newHashedPassword);
       
    }
}
