using MaintenanceSheduleSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class Order
    {
        private Order(Guid id,Guid machineId, Guid areaId, string name, string description,
            string servicemanName, DateTime createDate, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments)
        {
            Id = id;
            MachineAreaId = machineId;
            MachineAreaId = areaId;
            Name = name;
            Description = description;
            ServicemanName = servicemanName;
            CreateDate = createDate;
            DeadlineDate = deadlineDate;
            TypeOfWork = typeOfWork;
            Equipments = equipments;
        }
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public Guid MachineAreaId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ServicemanName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime StartWorkDate { get; set; } = DateTime.MinValue;
        public DateTime CompliteDate { get; set; } = DateTime.MinValue;
        public TypeOfWork TypeOfWork { get; set; } = TypeOfWork.None;
        public List<Equipment> Equipments { get; set; }
        public Order Create(Guid machineId, Guid areaId, string name, string description,string servicemanName, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments) 
        {
            return new Order(
                Guid.NewGuid(),
                machineId,
                areaId,
                name,
                description,
                servicemanName,
                DateTime.Now,
                deadlineDate,
                typeOfWork,
                equipments);
          
        }
    }


}
