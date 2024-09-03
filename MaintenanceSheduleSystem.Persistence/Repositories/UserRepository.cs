﻿using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaintenanceSheduleSystem.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAdministrator(Administrator administratorEntity)
        {
            UserEntity userPart = new UserEntity()
            {
                Id = administratorEntity.Id,
                FullName = administratorEntity.FullName.ToString(),
                Email = administratorEntity.Email,
                HashedPassword = administratorEntity.HashedPassword,
                Role = Core.Enums.Roles.Admin,
                IsSacked = false,
            };
            _dbContext.Users.Add(userPart);
          

            await _dbContext.SaveChangesAsync();
        }

        public Task AddPlannerEngineer(PlannerEngineer plannerEngineer)
        {
            throw new NotImplementedException();
        }

        public Task AddServiceman(Serviceman serviceman)
        {
            throw new NotImplementedException();
        }

        public Task Login(string email, string hashedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
