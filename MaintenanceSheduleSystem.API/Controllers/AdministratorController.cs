using MaintenanceSheduleSystem.Application.Services;
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
        [HttpPost("administrator")]
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

    }
}
