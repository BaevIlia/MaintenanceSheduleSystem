using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class InstructionEquipmentListEntity
    {
        public Guid InstructionId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Count { get; set; }

        public InstructionEntity? Instruction { get; set; }
        public EquipmentEntity? Equipment { get; set; }
    }
}
