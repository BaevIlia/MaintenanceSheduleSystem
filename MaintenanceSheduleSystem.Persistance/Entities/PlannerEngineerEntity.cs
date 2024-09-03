using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class PlannerEngineerEntity : UserEntity
    {
        public Guid UserId { get; set; }
        public UserEntity? UserEntity { get; set; }
    }
}
