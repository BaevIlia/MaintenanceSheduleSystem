using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class Equipment
    {
        private Equipment(Guid id, string article, string name, string storagePlace, EquipmentTypes type, int count)
        {
            Id = id;
            Article = article;
            Name = name;
            StoragePlace = storagePlace;
            Type = type;
            Count = count;
        }
        public Guid Id { get; set; }
        public string Article { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StoragePlace {get; set; } = string.Empty;
        public EquipmentTypes Type { get; set; }
        public int Count { get; set; }
        public bool IsInStock { get; set; }

     

    }
}
