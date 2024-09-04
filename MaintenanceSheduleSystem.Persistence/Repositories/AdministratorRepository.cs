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
        public async Task<Guid> Create(Administrator administrator)
        {
            AdministratorEntity entity = new() 
            {
                Id = administrator.Id,
                FullName = administrator.FullName.ToString(),
                Email = administrator.Email,
                HashedPassword = administrator.HashedPassword,
                IsSacked = false,
                Role = Core.Enums.Roles.Admin,
                SigningKey = administrator.OwnAcceptKey,
            };

            _dbContext.Administrators.Add(entity);

            await _dbContext.SaveChangesAsync();

            if (!_dbContext.Administrators.Any(a => a.Id == entity.Id)) 
            {
                throw new Exception("Ошибка создания пользователя");
            }
            return entity.Id;
        }
    }
}
