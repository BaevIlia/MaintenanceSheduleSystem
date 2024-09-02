using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class EquipmentEntity
    {
        public Guid Id { get; set; }
        public string Article { get; set; } = string.Empty;
        public string EquipmentName { get; set; } = string.Empty;
        public string StoragePlace { get; set; } = string.Empty;
        public EquipmentTypes EquipmentType  { get; set; }
        public bool IsCritical { get; set; }
        public bool IsInStock { get; set; }

        public ICollection<HandbookEntity>? HandbooksLists { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
