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
        Task<bool> CreateServiceman(Serviceman serviceman, Guid adminId, string signingKey);
        Task<object> GetProfile(Guid id);
        Task<bool> UpdateAdministrator(Guid id, string surname, string firstName, string lastName, string email);
        Task<bool> UpdatePlannerEngineer(Guid id, string surname, string firstName, string lastName, string email, string title, Guid adminId, string signingKey);
        Task<bool> UpdateServiceman(Guid id, string surname, string firstName, string lastName, string email, Guid adminId, string signingKey);
        Task<bool> DeleteProfile(Guid id);
        Task<bool> CreateKey(Guid id, string key);


    }
}
