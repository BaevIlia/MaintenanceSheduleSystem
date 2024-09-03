using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IUserRepository
    {
        Task AddAdministrator(Administrator administratorEntity);
        Task AddPlannerEngineer(PlannerEngineer plannerEngineer);
        Task AddServiceman(Serviceman serviceman);

        Task Login(string email, string hashedPassword);
    }
}
