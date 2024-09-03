using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }
        public Task AddAdmin(string surname, string firstName, string lastName, string email, string password)
        {
            Administrator administrator = Administrator.Create(Guid.NewGuid(), email, password, new FullName(surname, firstName, lastName), "12345");

            _userRepository.AddAdministrator(administrator);

            return Task.CompletedTask;

          

        }
    }
}
