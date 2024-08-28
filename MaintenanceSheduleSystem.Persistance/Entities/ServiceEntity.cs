using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class ServiceEntity
    {
        public Guid UserId { get; set; }

        public ICollection<OrderEntity> Orders { get; set; } = [];
    }
}
