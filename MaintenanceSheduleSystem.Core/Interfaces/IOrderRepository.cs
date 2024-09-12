﻿using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Models;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface IOrderRepository
    {
        public Task<ICollection<Order>> GetAllOrders();
        public Task<Order> GetOrderById();
        public Task<Guid> CreateOrder(string machineName, string areaName, string orderName, string orderDescription, string servicemanName, DateTime deadlineDate, TypeOfWork typeOfWork, List<Equipment> equipments);
        public Task<Guid> UpdateOrder();
        public Task<bool> DeleteOrder();
    }
}