using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderREpository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderREpository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return new List<Order>();
        }

        public async Task<Order> GetOrder()
        {
           
        }

        public async Task<Guid> CreateOrder() 
        {
            return Guid.Parse(string.Empty);
        }

        public async Task<Guid> UpdateOrder()
        {
            return Guid.Parse(string.Empty);
        }

        public async Task<bool> DeleteOrder()
        {
            return true;
        }
    }
}
