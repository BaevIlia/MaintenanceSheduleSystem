using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core
{
    public interface IUserRepository
    {
        public Task AddAdministrator(User userEntity, Administrator administratorEntity);
        public Task AddPlannerEngineer(PlannerEngineer plannerEngineer);
        public Task AddServiceman(Serviceman serviceman);

        public Task Login(string email, string hashedPassword);
    }
}
