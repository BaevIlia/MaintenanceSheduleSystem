using MaintenanceSheduleSystem.Core.Enums;
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

                if (!CheckIfExists(plannerEngineerEntity.Id)) 
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
        public async Task<bool> CreateServiceman(Serviceman serviceman, Guid adminId, string signingKey) 
        {

        }
        public async Task<object> GetProfile(Guid id) 
        {
            AdministratorEntity entity = await _dbContext.Administrators.FindAsync(id);

            Administrator profile = Administrator.Create(entity.Id, entity.Email, entity.HashedPassword, FullName.ParseFullName(entity.FullName), entity.SigningKey);

            return profile;
        }
        public async Task<bool> DeleteProfile(Guid id) 
        {
            UserEntity user = await _dbContext.Users.FindAsync(id);

            user.IsSacked = true;

            await _dbContext.SaveChangesAsync(); 

            return true;
        }

        public async Task<bool> UpdateProfile(Guid id, string surname, string firstName, string lastName, string email, string hashedPassword, Roles role) 
        {
           
            switch (role)
            {
                case Roles.Admin: 
                    {
                        AdministratorEntity entity = await _dbContext.Administrators.FindAsync(id);
                        entity.FullName = new FullName(surname, firstName, lastName).ToString();
                        entity.Email = email;
                        entity.Role = role;

                    }
                    break;
                case Roles.Planner: 
                    {
                        PlannerEngineerEntity entity = await _dbContext.PlannerEngineers.FindAsync(id);
                        entity.FullName = new FullName(surname, firstName, lastName).ToString();
                        entity.Email = email;
                        entity.Role = role;
                    }
                    break;
                case Roles.Service:  
                    {
                        ServicemanEntity entity = await _dbContext.Servicemen.FindAsync(id);
                        entity.FullName = new FullName(surname, firstName, lastName).ToString();
                        entity.Email = email;
                        entity.Role = role;
                    }
                    break;
                default:
                    throw new Exception("Такой роли не существует");
            }

            return true;
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
        private bool CheckIfExists(Guid id) 
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
