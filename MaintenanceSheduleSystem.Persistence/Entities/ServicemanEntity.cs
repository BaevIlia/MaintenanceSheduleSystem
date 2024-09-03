using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    [Table("Servicemen")]
    public class ServicemanEntity : UserEntity 
    { 
        public ICollection<OrderEntity>? Orders { get; set; } 
    }
}
