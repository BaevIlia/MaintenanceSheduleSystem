using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Infrastructure.OutsideServiceOptions
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } =string.Empty;
        public int ExpitesHours { get; set; }
    }
}
