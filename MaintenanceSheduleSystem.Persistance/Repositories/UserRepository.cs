using MaintenanceSheduleSystem.Core;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UserRepository(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task AddAdministrator(User userEntity, Administrator administratorEntity)
        {
            _dbContext.Add(userEntity);
            _dbContext.Add(administratorEntity);

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
