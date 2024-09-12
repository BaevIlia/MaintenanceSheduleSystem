using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Dto.UserBaseDto_s
{
    public record ChangePasswordDto(string userId, string newPassword);
}
