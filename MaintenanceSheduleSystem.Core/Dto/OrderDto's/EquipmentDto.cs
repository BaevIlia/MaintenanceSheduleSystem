using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Dto.OrderDto_s
{
    public class EquipmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public int Count { get; set; }
        public EquipmentTypes Type { get; set; }
    }
}
