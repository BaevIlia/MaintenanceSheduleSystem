using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class EquipmentEntity
    {
        public Guid Id { get; set; }
        public string Article { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StoragePlace { get; set; } = string.Empty;
        public EquipmentTypes Type  { get; set; }
        public int Count { get; set; }
        public bool IsInStock { get; set; }

        public ICollection<InstructionEntity>? Instructions { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
