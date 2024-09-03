using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Entities
{
    [Table("Administartors")]
    public class AdministratorEntity : UserEntity
    {
        public string SigningKey { get; set; } = string.Empty;
    }
}
