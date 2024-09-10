using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class Handbook
    {
        private Handbook()
        {
            
        }

        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public Guid AreaId { get; set; }
        public TypeOfWork TypeOfWork { get; set; }
        public string Description { get; set; }
        public Guid EquipmentListId { get; set; }
    }
}
