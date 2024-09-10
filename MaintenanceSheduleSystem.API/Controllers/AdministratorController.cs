using MaintenanceSheduleSystem.Application.Services;
using MaintenanceSheduleSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdministratorController : ControllerBase
    {
        private readonly AdministratorService _administratorService;
        
        public AdministratorController(AdministratorService administartorService) 
        {
            _administratorService = administartorService;
         
        }
        [HttpPost("createPlanner")]
        public async Task<IActionResult> CreatePlanner(string adminId, string surname, string firstName, string lastName, string email, string password, string title, string signingKey) 
        {
            var result = await _administratorService.CreatePlanner(
                Guid.Parse(adminId),
                surname,
                firstName,
                lastName,
                email,
                password,
                title,
                signingKey);

            if (!result) 
            {
                return BadRequest("Ошибка создания планёра");
            }
            return Ok(result);
        }
        [HttpPost("createServiceman")]
        public async Task<IActionResult> CreateServiceman(string adminId, string surname, string firstName, string lastName, string email, string password, string signingKey) 
        {
            var result = await _administratorService.CreateServiceman(Guid.Parse(adminId), surname, firstName, lastName, email, password, signingKey);
            if (!result)
                return BadRequest("Ошибка создания сотрудника сервиса");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(string id) 
        {
            var result = await _administratorService.GetProfile(Guid.Parse(id));

            if (result is null) 
            {
                return BadRequest("Такого профиля не существует");
            }
            return Ok(result);
        }
        [HttpPut("updateAdmin")]
        public async Task<IActionResult> UpdateAdmin(string id, string surname, string firstName, string lastName, string email) 
        {
            var result = await _administratorService.UpdateAdminProfile(Guid.Parse(id), surname, firstName, lastName, email);

            if (!result)
                return BadRequest("Ошибка обновления профиля администратора");
            return Ok(result);
        }
        [HttpPut("updatePlanner")]
        public async Task<IActionResult> UpdatePlannerEngineer(string adminId, string signingKey, string id, string surname, string firstName, string lastName,string title, string email)
        {
            var result = await _administratorService.UpdatePlannerProfile(Guid.Parse(adminId), signingKey, Guid.Parse(id), surname, firstName, lastName, email, title);
            if (!result)
                return BadRequest("Ошибка обновления профиля планёра");
            return Ok(result);
        }
        [HttpPut("updateServiceman")]
        public async Task<IActionResult> UpdateServiceman(string adminId, string signingKey, string id, string surname, string firstName, string lastName, string email)
        {
            var result = await _administratorService.UpdateServicemanProfile(Guid.Parse(adminId), signingKey, Guid.Parse(id), surname, firstName, lastName, email);

            if (!result)
                return BadRequest("Ошибка обновления профиля сервисного сотрудника");
            return Ok(result);
        }

        [HttpPatch("deleteProfile")]
        public async Task<IActionResult> DeleteProfile(string id) 
        {
            var result = await _administratorService.DeleteProfile(Guid.Parse(id));

            if (!result)
                return BadRequest("Ошибка удаления профиля");
            return Ok(result);
        }

        [HttpPost("createSigningKey")]
        public async Task<IActionResult> CreateSigningKey(string id) 
        {
           var result = await _administratorService.CreateSigningKey(Guid.Parse(id));
            if (String.IsNullOrWhiteSpace(result.ToString()))
                return BadRequest("Ошибка создания ключа подписи");

            return Ok(result);
        }
    }
}
