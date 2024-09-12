using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<ICollection<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
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
