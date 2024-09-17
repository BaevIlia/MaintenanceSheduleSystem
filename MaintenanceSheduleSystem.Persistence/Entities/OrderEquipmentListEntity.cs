using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class OrderEquipmentListEntity
    {
        public Guid OrderId { get; set; }
        public Guid EquipmentId { get; set; }

        public int EquipmentCount { get; set; }

        public OrderEntity? Order { get; set; }
        public EquipmentEntity? Equipment { get; set; }
       
    }
}
