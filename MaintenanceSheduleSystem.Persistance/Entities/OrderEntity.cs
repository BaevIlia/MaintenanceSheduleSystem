using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ServicemanName { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime BeginWorkDateTime { get; set; }
        public DateTime CompliteDateTime { get; set; }
    }
}
