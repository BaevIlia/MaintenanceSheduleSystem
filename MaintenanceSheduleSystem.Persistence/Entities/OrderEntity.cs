using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public Guid AreaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid PlannerEngineerId { get; set; }
        public Guid ServicemanId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? BeginWorkDateTime { get; set; }
        public DateTime? DeadlineDateTime { get; set; }
        public DateTime? CompliteDateTime { get; set; }
        public TypeOfWork TypeOfWork { get; set; }
        public MachineAreaEntity? MachineArea { get; set; }
        public ServicemanEntity? Serviceman { get; set; }
        public PlannerEngineerEntity? PlannerEngineer { get; set; }
        public ICollection<EquipmentEntity>? Equipments { get; set; }
    }
}
