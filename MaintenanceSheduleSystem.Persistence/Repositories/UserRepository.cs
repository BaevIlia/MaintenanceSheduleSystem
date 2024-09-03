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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAdministrator(Administrator administrator)
        {

            AdministratorEntity administratorEntity = new AdministratorEntity()
            {
                Id = administrator.Id,
                Email = administrator.Email,
                HashedPassword = administrator.HashedPassword,
                FullName = administrator.FullName.ToString(),
                Role = Core.Enums.Roles.Admin,
                IsSacked = false,
                SigningKey = administrator.OwnAcceptKey
            };
           await _dbContext.AddAsync(administratorEntity);

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
