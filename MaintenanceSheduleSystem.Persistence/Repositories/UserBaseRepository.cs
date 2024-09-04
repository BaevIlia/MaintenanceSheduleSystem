using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistence.Repositories
{
    public class UserBaseRepository : IUserBaseRepository
    {
        private readonly ApplicationDbContext _context;

        public UserBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByEmail(string email)
        {
            UserEntity userEntity = await _context.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();

            User user = new(userEntity.Id, userEntity.Email, userEntity.HashedPassword, FullName.ParseFullName(userEntity.FullName), userEntity.Role);


            return user;
        }
    }
}
