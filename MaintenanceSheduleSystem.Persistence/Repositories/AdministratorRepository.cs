using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            if (CheckSignKey(adminId, signingKey))
            {
                ServicemanEntity entity = new()
                {
                    Id = serviceman.Id,
                    FullName = serviceman.FullName.ToString(),
                    Email = serviceman.Email,
                    HashedPassword = serviceman.HashedPassword,
                    IsSacked = false,
                    Role = Core.Enums.Roles.Service,
                };

                await _dbContext.Servicemen.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                if (!CheckIfExists(entity.Id))
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
        public async Task<bool> DeleteProfile(Guid id)
        {
            UserEntity user = await _dbContext.Users.FindAsync(id);

            user.IsSacked = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAdministrator(Guid id, string surname, string firstName, string lastName, string email)
        {
          
                AdministratorEntity entity = await _dbContext.Administrators.FindAsync(id);

                entity.FullName = new FullName(surname, firstName, lastName).ToString();
                entity.Email = email;

                await _dbContext.SaveChangesAsync();

                await _dbContext.Administrators
                    .Where(a => a.Id.Equals(id))
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.FullName, new FullName(surname, firstName, lastName).ToString())
                    .SetProperty(a => a.Email, email)
                    );

                
            
            return true;


        }
        public async Task<bool> UpdatePlannerEngineer(Guid id, string surname, string firstName, string lastName, string email, string title, Guid adminId, string signingKey)
        {
            if (CheckSignKey(adminId, signingKey))
            {
                PlannerEngineerEntity entity = await _dbContext.PlannerEngineers.FindAsync(id);

                await _dbContext.PlannerEngineers
                    .Where(p => p.Id.Equals(id))
                    .ExecuteUpdateAsync(p => p
                    .SetProperty(p => p.FullName, new FullName(surname, firstName, lastName).ToString())
                    .SetProperty(p => p.Email, email)
                    .SetProperty(p => p.Title, title)
                    );


                return true;

            }
            else
            {
                throw new Exception("Ключ подписания не соответствует ключу подписания данной учётной записи администратора");
            }
        }
        public async Task<bool> UpdateServiceman(Guid id, string surname, string firstName, string lastName, string email, Guid adminId, string signingKey)
        {
            if (CheckSignKey(adminId, signingKey))
            {

                ServicemanEntity entity = await _dbContext.Servicemen.FindAsync(id);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Servicemen
                    .Where(s => s.Id.Equals(id))
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.FullName, new FullName(surname, firstName, lastName).ToString())
                    .SetProperty(p => p.Email, email)
                    );
                return true;

            }
            else 
            {
                throw new Exception("Ключ подписания не соответствует ключу подписания данной учётной записи администратора");
            }
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
