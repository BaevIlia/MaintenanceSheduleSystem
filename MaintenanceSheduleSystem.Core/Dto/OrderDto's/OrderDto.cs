using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Dto.OrderDto_s
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MachineName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string PlannerName { get; set; } = string.Empty;
        public string ServicemanName { get; set; } =string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public DateTime? BeginWorkDateTime { get; set; }
        public DateTime? DeadlineDateTime { get; set; }
        public DateTime? CompliteDateTime { get; set; }
        public TypeOfWork TypeOfWork { get; set; }
        public List<EquipmentDto>? Equipment { get; set; }
    }
}
