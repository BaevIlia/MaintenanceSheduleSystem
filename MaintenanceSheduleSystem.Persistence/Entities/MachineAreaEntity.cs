using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class MachineAreaEntity
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public string AreaName { get; set; } = string.Empty;
        public string AreaDescription { get; set; } =string.Empty;
        public MachineEntity? Machine { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
        public ICollection<InstructionEntity>? Instructions { get; set; }
    }
}
