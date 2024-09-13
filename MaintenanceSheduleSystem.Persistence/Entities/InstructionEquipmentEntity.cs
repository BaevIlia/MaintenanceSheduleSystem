using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class InstructionEquipmentEntity
    {
        public Guid InstructionId { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
