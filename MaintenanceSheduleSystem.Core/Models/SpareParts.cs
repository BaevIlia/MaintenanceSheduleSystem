using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class SpareParts
    {
        public Guid Id { get; set; }
        public string Article { get; set; } = string.Empty;
        public string InstrumentName { get; set; } = string.Empty;
        public string StoragePlace { get; set; } = string.Empty;

        public bool IsInStock { get; set; }

    }
}
