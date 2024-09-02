using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class OrderEquipmentList
    {
        public Guid EquipmentId { get; set; }
        public Guid OrderId { get; set; }
    }
}
