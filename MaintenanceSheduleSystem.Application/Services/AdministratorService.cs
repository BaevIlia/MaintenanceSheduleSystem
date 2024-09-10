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
    public class AdministratorService
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IPasswordHasher _passwordHasher;
        private string PATH = $@"{Environment.CurrentDirectory}/key.txt";

        public AdministratorService(IAdministratorRepository administratorRepository, IPasswordHasher passwordHasher)
        {
            _administratorRepository = administratorRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> CreatePlanner(Guid adminId, string surname, string firstName, string lastName, string email, string password, string title, string signingKey) 
        {
            string hashedPassword = _passwordHasher.Generate(password);
            PlannerEngineer planner = PlannerEngineer.Create(Guid.NewGuid(), email, hashedPassword, new FullName(surname, firstName, lastName), title);

            var result = await _administratorRepository.CreatePlanner(planner, adminId, signingKey);

           
            return result;
        }
        public async Task<bool> CreateServiceman(Guid adminId, string surname, string firstName, string lastName, string email, string password, string signingKey)
        {
            string hashedPassword = _passwordHasher.Generate(password);
            Serviceman serviceman = Serviceman.Create(Guid.NewGuid(), email, hashedPassword, new FullName(surname, firstName, lastName));

            var result = await _administratorRepository.CreateServiceman(serviceman, adminId, signingKey);

            return result;
        }

        public async Task<bool> UpdateAdminProfile(Guid id, string surname, string firstName, string lastName, string email) 
        {
            var result = await _administratorRepository.UpdateAdministrator(id, surname, firstName, lastName, email);
            return result;
        }
        public async Task<bool> UpdatePlannerProfile(Guid adminId, string signingKey, Guid id, string surname, string firstName, string lastName, string email, string title)
        {
            var result = await _administratorRepository.UpdatePlannerEngineer(id, surname, firstName, lastName, email, title, adminId, signingKey);

            return result;
        }
        public async Task<bool> UpdateServicemanProfile(Guid adminId, string signingKey, Guid id, string surname, string firstName, string lastName, string email)
        {
            var result = await _administratorRepository.UpdateServiceman(id, surname, firstName, lastName, email, adminId, signingKey);

            return result;
        }

        public async Task<bool> DeleteProfile(Guid id) 
        {
            var result = await _administratorRepository.DeleteProfile(id);

            return result;
        }
        public async Task<object> GetProfile(Guid id) 
        {
            var result = await _administratorRepository.GetProfile(id);

            return result;
        }

        public async Task<Guid> CreateSigningKey(Guid id) 
        {
            Guid signingKey = Guid.NewGuid();
            var result = await _administratorRepository.CreateKey(id, signingKey.ToString());
            if (!result) 
            {
                throw new Exception("Ошибка записи ключа в БД");
            }
            using (FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate)) 
            {
                using (StreamWriter streamWriter = new StreamWriter(fs))
                    await streamWriter.WriteLineAsync(signingKey.ToString());
            }
            return signingKey;
        }
    }
}
