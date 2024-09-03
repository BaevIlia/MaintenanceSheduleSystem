using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IUserService
    {
        Task AddAdmin(string surname, string firstName, string lastName, string email, string password);
    }
}
