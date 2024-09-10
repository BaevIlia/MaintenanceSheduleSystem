using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class MachineArea
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public string AreaName { get; set; } = string.Empty;
        public string AreaDescription { get; set; } = string.Empty;
        public List<Instruction> Instructions { get; set; } = [];

    }
}
