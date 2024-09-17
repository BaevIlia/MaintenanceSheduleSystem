using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class InstructionEntity
    {
        public Guid Id { get; set; }
        public Guid AreaId { get; set; }
        public TypeOfWork TypeOfWork { get; set; }
        public string Instructions { get; set; } = string.Empty;

        public MachineAreaEntity? MachineArea { get; set; }
        public ICollection<InstructionEquipmentListEntity>? InstructionEquipmentLists { get; set; }
  
    }
}
