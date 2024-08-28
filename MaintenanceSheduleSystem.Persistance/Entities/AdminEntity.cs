using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class AdminEntity
    {
        public Guid UserId { get; set; }
        public string OwnAcceptKey { get; set; } = string.Empty;

    }
}
