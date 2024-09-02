using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class HandbookEquipmentEntity
    {
        public Guid HandbookId { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
