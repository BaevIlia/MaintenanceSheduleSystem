using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;


namespace MaintenanceSheduleSystem.Persistence.Repositories
{
    public class UserBaseRepository : IUserBaseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        public UserBaseRepository(ApplicationDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task<bool> ChangePassword(User user,  string newHashedPassword)
        {
            if (user is null) 
            {
                throw new ArgumentNullException("Пользователя не существует");
            }
            if (newHashedPassword.Equals(user.HashedPassword)) 
            {
                throw new Exception("Придумайте новый пароль");
            }
            user.HashedPassword = newHashedPassword;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByEmail(string email)
        {
            UserEntity? userEntity = await _cacheService.GetFromCache<UserEntity>(email);

            if (userEntity is null) 
            {
                userEntity = await _context.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
                await _cacheService.WriteToCache(userEntity, email);
            }

            User user = new(userEntity.Id, userEntity.Email, userEntity.HashedPassword, FullName.ParseFullName(userEntity.FullName), userEntity.Role);


            return user;
        }
        public async Task<User> GetById(Guid id) 
        {

            UserEntity userEntity = await _cacheService.GetFromCache<UserEntity>(id.ToString());

            if (userEntity is null) 
            {
                userEntity = await _context.Users.FindAsync(id);
                await _cacheService.WriteToCache(userEntity, id.ToString());
            }

            User user = new(userEntity.Id, userEntity.Email, userEntity.HashedPassword, FullName.ParseFullName(userEntity.FullName), userEntity.Role);

            return user;
        }
     

       
    }
}
