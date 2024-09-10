using MaintenanceSheduleSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    public class PlannerEngineerEntity : UserEntity
    {
        public string Title { get; set; } = string.Empty;
    }
}
