using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Dto.AdministratorDto_s
{
    public record UpdatePlannerEngineerDto(string adminId, string signingKey, string id, string surname, string firstName, string lastName, string title, string email);
}
