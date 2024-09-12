using MaintenanceSheduleSystem.Core.Models;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IOrderRepository
    {
        public Task<ICollection<Order>> GetAllOrders();
        public Task<Order> GetOrderById();
        public Task<Guid> CreateOrder();
        public Task<Guid> UpdateOrder();
        public Task<bool> DeleteOrder();
    }
}