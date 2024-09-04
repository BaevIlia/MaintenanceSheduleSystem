using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application.Services
{
    public class AdministratorService
    {
        private readonly IAdministratorRepository _repository;
        private readonly IPasswordHasher _passwordHasher;
        public AdministratorService(IAdministratorRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> CreateAdministrator(string surname, string firstName, string lastName, string email, string password) 
        {
            string signingKey = Guid.NewGuid().ToString();

            string hashedPassword = _passwordHasher.Generate(password);

            Administrator administrator = Administrator.Create(
                id: Guid.NewGuid(),
                email: email,
                hashedPassword: hashedPassword,
                fullName: new FullName(surname, firstName, lastName),
                ownAcceptKey: signingKey);

            Guid result = await _repository.Create(administrator);

            return result;
        }
    }
}
