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
        private Order(Guid id, Guid areaId, string name, string description, DateTime createDate, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments)
        {
            Id = id;
            AreaId = areaId;
            Name = name;
            Description = description;
            CreateDate = createDate;
            DeadlineDate = deadlineDate;
            TypeOfWork = typeOfWork;
            Equipments = equipments;
        }
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public Guid AreaId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime StartWorkDate { get; set; } = DateTime.MinValue;
        public DateTime CompliteDate { get; set; } = DateTime.MinValue;
        public TypeOfWork TypeOfWork { get; set; } = TypeOfWork.None;
        public List<Equipment> Equipments { get; set; }
        public Order Create(Guid areaId, string name, string description, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments) 
        {
            return new Order(
                Guid.NewGuid(),
                areaId,
                name,
                description,
                DateTime.Now,
                deadlineDate,
                typeOfWork,
                equipments);
          
        }
    }


}
