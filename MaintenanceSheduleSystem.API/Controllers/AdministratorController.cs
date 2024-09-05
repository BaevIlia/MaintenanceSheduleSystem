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
        private readonly AdministartorService _administartorService;
        public AdministratorController(AdministartorService administartorService)
        {
            _administartorService = administartorService;
        }
        [HttpPost("createPlanner")]
        public async Task<IActionResult> CreatePlanner(string adminId, string surname, string firstName, string lastName, string email, string password, string title, string signingKey) 
        {
            var result = await _administartorService.CreatePlanner(
                Guid.Parse(adminId),
                surname,
                firstName,
                lastName,
                email,
                password,
                title,
                signingKey);

            return Ok(result);
        }
        [HttpPost("createServiceman")]
        public async Task<IActionResult> CreateServiceman(string adminId, string surname, string firstName, string lastName, string email, string password, string signingKey) 
        {
            var result = await _administartorService.CreateServiceman(Guid.Parse(adminId), surname, firstName, lastName, email, password, signingKey);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(string id) 
        {
            var result = await _administartorService.GetProfile(Guid.Parse(id));

            return Ok(result);
        }
        [HttpPut("updateAdmin")]
        public async Task<IActionResult> UpdateAdmin(string adminId, string signingKey,string id, string surname, string firstName, string lastName, string email) 
        {
            var result = await _administartorService.UpdateAdminProfile(Guid.Parse(adminId), signingKey, Guid.Parse(id), surname, firstName, lastName, email);

            return Ok(result);
        }
        [HttpPut("updatePlanner")]
        public async Task<IActionResult> UpdatePlannerEngineer(string adminId, string signingKey, string id, string surname, string firstName, string lastName,string title, string email)
        {
            var result = await _administartorService.UpdatePlannerProfile(Guid.Parse(adminId), signingKey, Guid.Parse(id), surname, firstName, lastName, email, title);

            return Ok(result);
        }
        [HttpPut("updateServiceman")]
        public async Task<IActionResult> UpdateServiceman(string adminId, string signingKey, string id, string surname, string firstName, string lastName, string email)
        {
            var result = await _administartorService.UpdateServicemanProfile(Guid.Parse(adminId), signingKey, Guid.Parse(id), surname, firstName, lastName, email);


            return Ok(result);
        }

        [HttpPatch("deleteProfile")]
        public async Task<IActionResult> DeleteProfile(string id) 
        {
            var result = await _administartorService.DeleteProfile(Guid.Parse(id));

            return Ok(result);
        }
    }
}
