using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Dto.AdministratorDto_s
{
    public record CreateServicemanDto(string adminId, string surname, string firstName, string lastName, string email, string password, string signingKey);
}
