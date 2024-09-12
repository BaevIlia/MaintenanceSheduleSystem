using MaintenanceSheduleSystem.Application.Services;
using MaintenanceSheduleSystem.Core.Dto.AdministratorDto_s;
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
        public async Task<IActionResult> CreatePlanner(CreatePlannerEngineerDto request) 
        {
            var result = await _administratorService.CreatePlanner(
                Guid.Parse(request.adminId),
                request.surname,
                request.firstName,
                request.lastName,
                request.email,
                request.password,
                request.title,
                request.signingKey);

            if (!result) 
            {
                return BadRequest("Ошибка создания планёра");
            }
            return Ok(result);
        }
        [HttpPost("createServiceman")]
        public async Task<IActionResult> CreateServiceman(CreateServicemanDto request) 
        {
            var result = await _administratorService.CreateServiceman(
                Guid.Parse(request.adminId),
                request.surname,
                request.firstName,
                request.lastName, 
                request.email, 
                request.password,
                request.signingKey);
            if (!result)
                return BadRequest("Ошибка создания сотрудника сервиса");
            return Ok(result);
        }

        [HttpGet("getProfile/{id}")]
        public async Task<IActionResult> GetProfile(string id) 
        {
            var result = await _administratorService.GetProfile(Guid.Parse(id));

            if (result is null) 
            {
                return NotFound("Такого профиля не существует");
            }
            return Ok(result);
        }
        [HttpPut("updateAdmin")]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDto request) 
        {
            var result = await _administratorService.UpdateAdminProfile(
                Guid.Parse(request.id),
                request.surname,
                request.firstName,
                request.lastName,
                request.email);

            if (!result)
                return BadRequest("Ошибка обновления профиля администратора");
            return Ok(result);
        }
        [HttpPut("updatePlanner")]
        public async Task<IActionResult> UpdatePlannerEngineer(UpdatePlannerEngineerDto request)
        {
            var result = await _administratorService.UpdatePlannerProfile(
                Guid.Parse(request.adminId),
                request.signingKey,
                Guid.Parse(request.id),
                request.surname,
                request.firstName,
                request.lastName,
                request.email,
                request.title);
            if (!result)
                return BadRequest("Ошибка обновления профиля планёра");
            return Ok(result);
        }
        [HttpPut("updateServiceman")]
        public async Task<IActionResult> UpdateServiceman(UpdateServicemanDto request)
        {
            var result = await _administratorService.UpdateServicemanProfile(
                Guid.Parse(request.adminId), 
                request.signingKey,
                Guid.Parse(request.id),
                request.surname,
                request.firstName,
                request.lastName,
                request.email);

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
