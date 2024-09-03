using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Entities
{
    public class AdministratorEntity
    {
        public Guid UserId { get; set; }
        public string SigningKey { get; set; } = string.Empty;
        public UserEntity? UserEntity { get; set; }
    }
}
