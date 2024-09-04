using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;


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
        public async Task<User> GetById(Guid id) 
        {
            UserEntity userEntity = await _context.Users.FindAsync(id);

            User user = new(userEntity.Id, userEntity.Email, userEntity.HashedPassword, FullName.ParseFullName(userEntity.FullName), userEntity.Role);

            return user;
        }
    }
}
