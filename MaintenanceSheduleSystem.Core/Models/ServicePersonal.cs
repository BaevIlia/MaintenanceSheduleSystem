﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Core.Enums;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class ServicePersonal : User
    {
        private ServicePersonal(Guid id, string email, string hashedPassword, FullName fullName, Roles role, List<WorkOrder> workOrders) : base(id, email, hashedPassword, fullName, role)
        {
            WorkOrders = workOrders;
        }

        public static ServicePersonal Create(Guid id, string email, string hashedPassword, FullName fullName, List<WorkOrder> workOrders) 
        {
            return new ServicePersonal(id, email, hashedPassword, fullName, role: Roles.Service, workOrders);
        }

        public List<WorkOrder> WorkOrders { get; set; }


    }
}
