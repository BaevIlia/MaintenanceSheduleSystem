using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class MachineEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

        public ICollection<MachineAreaEntity>? Areas { get; set; }
    }
}
