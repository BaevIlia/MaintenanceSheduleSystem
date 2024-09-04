﻿using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application.Services
{
    public class UserBaseService
    {
        private readonly IUserBaseRepository _userBaseRepository;
        private readonly IPasswordHasher _passwordHasher; 
        
        public UserBaseService(IUserBaseRepository userBaseRepository, IPasswordHasher passwordHasher)
        {
            _userBaseRepository = userBaseRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Login(string email, string password) 
        {
            User user = await _userBaseRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.HashedPassword);

            

            return Guid.NewGuid().ToString();
        }

        public async Task<string> GetById(Guid id) 
        {
            User user = await _userBaseRepository.GetById(id);

            return user.Id.ToString();
        }
    }
}
