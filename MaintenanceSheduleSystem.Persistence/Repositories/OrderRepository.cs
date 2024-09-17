using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MaintenanceSheduleSystem.Core.Dto.OrderDto_s;

namespace MaintenanceSheduleSystem.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Guid> CreateOrder(string machineName, string areaName, string orderName, string orderDescription, string servicemanName, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var allOrders = await _dbContext.Orders.Include(ol => ol.OrderEquipmentList).ToListAsync();

            List<Order> result = new();

            foreach (var order in allOrders) 
            {
                result.Add(await ToOrder(order));
            }

            return result;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var entity = await _dbContext.Orders.Include(ol => ol.OrderEquipmentList).Where(o=>o.Id.Equals(id)).FirstOrDefaultAsync();

            var order = await ToOrder(entity);

            return order;
        }

        public Task<Guid> UpdateOrder()
        {
            throw new NotImplementedException();
        }


        private async Task<Order> ToOrder(OrderEntity entity) 
        {
            Order result = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Equipments = await ToEquipmentList(entity.OrderEquipmentList)
            };

            return result;
        }

        private async Task<List<Equipment>> ToEquipmentList(ICollection<OrderEquipmentListEntity> equipments) 
        {
            List<Equipment> resultEquipment = new();

            foreach (var equipment in equipments) 
            {
                resultEquipment.Add(
                    new Equipment
                    {
                        Id = equipment.EquipmentId,
                        Name = await _dbContext.Equipments.Where(e => e.Id.Equals(equipment.EquipmentId)).Select(n => n.Name).FirstOrDefaultAsync(),
                        Count = equipment.EquipmentCount,
                        Type = await _dbContext.Equipments.Where(e=>e.Id.Equals(equipment.EquipmentId)).Select(t=>t.Type).FirstOrDefaultAsync()
                        
                    });
            }
            return resultEquipment;
        }
    }
}
