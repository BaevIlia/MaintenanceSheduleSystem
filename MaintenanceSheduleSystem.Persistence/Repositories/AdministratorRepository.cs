using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AdministratorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreatePlanner(PlannerEngineer planner, Guid adminId, string signingKey) 
        {
            if (CheckSignKey(adminId, signingKey))
            {
                PlannerEngineerEntity plannerEngineerEntity = new()
                {
                    Id = planner.Id,
                    FullName = planner.FullName.ToString(),
                    Email = planner.Email,
                    HashedPassword = planner.HashedPassword,
                    IsSacked = false,
                    Role = Core.Enums.Roles.Planner,
                    Title = planner.Title
                };

                await _dbContext.PlannerEngineers.AddAsync(plannerEngineerEntity);
                await _dbContext.SaveChangesAsync();

                if (!ChechIfExists(plannerEngineerEntity.Id)) 
                {
                    throw new Exception("Ошибка записи в базу данных");
                }

                return true;
            }
            else 
            {
                throw new Exception("Ключ подписания не соответствует ключу подписания данной учётной записи администратора");
                
            }
           

            
        }
        public async Task<object> GetProfile(Guid id) 
        {
            AdministratorEntity entity = await _dbContext.Administrators.FindAsync(id);

            Administrator profile = Administrator.Create(entity.Id, entity.Email, entity.HashedPassword, FullName.ParseFullName(entity.FullName), entity.SigningKey);

            return profile;
        }

        private bool CheckSignKey(Guid adminId, string signKey) 
        {
            var admin = _dbContext.Administrators.Find(adminId);

            if (!admin.SigningKey.Equals(signKey))
            {
                return false;
            }
            return true;
        }
        private bool ChechIfExists(Guid id) 
        {
            var result = _dbContext.Users.Find(id);
            if (result is null) 
            {
                return false;
            }
            return true;
        }
    }
}
