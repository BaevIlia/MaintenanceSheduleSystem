using MaintenanceSheduleSystem.Core.Enums;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application.Services
{
    public class UserBaseService
    {
        private readonly IUserBaseRepository _userBaseRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProviderService _jwtProviderService;
        public UserBaseService(IUserBaseRepository userBaseRepository, IPasswordHasher passwordHasher, IJwtProviderService jwtProviderService)
        {
            _userBaseRepository = userBaseRepository;
            _passwordHasher = passwordHasher;
            _jwtProviderService = jwtProviderService;
        }

        public async Task<string> Login(string email, string password)
        {
            User user = await _userBaseRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.HashedPassword);

            var token = _jwtProviderService.GenerateToken(user);

            return token;
        }

        public async Task<User> GetById(Guid id)
        {
            User user = await _userBaseRepository.GetById(id);

            return user;
        }
        public async Task<User> GetByEmail(string email) 
        {
            User user = await _userBaseRepository.GetByEmail(email);

            return user;
        }

        public async Task<bool> ChangePassword(Guid id, string newPassword)
        {
            User user = await _userBaseRepository.GetById(id);

            if (user is null)
            {
                throw new ArgumentNullException("Пользователя не существует");
            }
            if (_passwordHasher.Verify(newPassword, user.HashedPassword))
            {
                throw new Exception("Пожалуйста, введите пароль, отличный от старого");
            }
            string newHashedPassword = _passwordHasher.Generate(newPassword);

            var result = await _userBaseRepository.ChangePassword(user, newHashedPassword);

            if (!result)
            {
                throw new Exception("При изменении пароля произошла ошибка");
            }
            return result;
        }

      

       
    }
}
