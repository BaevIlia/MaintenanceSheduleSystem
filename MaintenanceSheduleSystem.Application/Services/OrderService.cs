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
            var result = await _orderREpository.GetAllOrders();

            return result;
        }

        public async Task<Order> GetOrder(string id)
        {
            var result = await _orderREpository.GetOrderById(Guid.Parse(id));

            return result;
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
