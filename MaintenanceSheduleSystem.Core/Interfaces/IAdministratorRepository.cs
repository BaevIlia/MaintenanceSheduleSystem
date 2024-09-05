using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<bool> CreatePlanner(PlannerEngineer planner, Guid adminId, string signingKey);
        Task<object> GetProfile(Guid id);
        Task<bool> UpdateProfile(Guid id, string surname, string firstName, string lastName, string email, string hashedPassword, Roles role);
        Task<bool> DeleteProfile(Guid id);


    }
}
