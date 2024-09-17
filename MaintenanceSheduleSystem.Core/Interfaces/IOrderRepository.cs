using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrders();
        public Task<Order> GetOrderById(Guid id);
        public Task<Guid> CreateOrder(string machineName, string areaName, string orderName, string orderDescription, string servicemanName, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments);
        public Task<Guid> UpdateOrder();
        public Task<bool> DeleteOrder();
    }
}