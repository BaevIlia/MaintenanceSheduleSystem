using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Repositories
{
    public class PlannerEngineerRepository : IOrderRepository
    {
        public Task<Guid> CreateOrder()
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
