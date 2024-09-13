using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Mapster;

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

        public async Task<ICollection<Order>> GetAllOrders()
        {
            var allOrders = await _dbContext.Orders.Include(e=>e.Equipments).ToListAsync();

            List<Order> result = new();

            foreach (var order in allOrders) 
            {
                result.Add(order.Adapt<Order>());
            }

            return result;
        }

        public Task<Order> GetOrderById()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
