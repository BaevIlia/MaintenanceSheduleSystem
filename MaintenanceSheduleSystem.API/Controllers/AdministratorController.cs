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
        public async Task<IActionResult> CreateServiceman(string adminId, string surname, string firstName, string lastName, string email, string password, string title, string signingKey) 
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(string id) 
        {
            var result = await _administartorService.GetProfile(Guid.Parse(id));

            return Ok(result);
        }

        [HttpPut("udpateProfile")]
        public async Task<IActionResult> UpdateProfile(string profileId,string surname, string firstName, string lastName, string email, Roles role) 
        {

        }

        [HttpPatch("deleteProfile")]
        public async Task<IActionResult> DeleteProfile(string id) 
        {

        }
    }
}
