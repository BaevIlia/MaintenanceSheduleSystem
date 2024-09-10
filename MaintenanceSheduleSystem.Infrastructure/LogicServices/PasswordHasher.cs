﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Core.Interfaces;

namespace MaintenanceSheduleSystem.Infrastructure.LogicServices
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)
        {
           return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
