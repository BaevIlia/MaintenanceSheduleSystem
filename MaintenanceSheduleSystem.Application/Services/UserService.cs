using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }
        public async Task AddAdministrator(string surname, string firstName, string lastName, string email, string password) 
        {
            Administrator administrator = Administrator.Create(id: Guid.NewGuid(),
                email: email,
                hashedPassword: password,
                fullName: new FullName(surname, firstName, lastName),
                ownAcceptKey: "1234"
                );

            await _userRepository.AddAdministrator(administrator);

            
        }

    }
}
