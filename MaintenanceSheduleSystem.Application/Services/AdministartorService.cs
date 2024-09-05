using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Application.Services
{
    public class AdministartorService
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AdministartorService(IAdministratorRepository administratorRepository, IPasswordHasher passwordHasher)
        {
            _administratorRepository = administratorRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> CreatePlanner(Guid adminId, string surname, string firstName, string lastName, string email, string password, string title, string signingKey) 
        {
            string hashedPassword = _passwordHasher.Generate(password);
            PlannerEngineer planner = PlannerEngineer.Create(Guid.NewGuid(), email, hashedPassword, new FullName(surname, firstName, lastName), title);

            var result = await _administratorRepository.CreatePlanner(planner, adminId, signingKey);

            if (!result) 
            {
                return false;
            }
            return true;
        }
    }
}
