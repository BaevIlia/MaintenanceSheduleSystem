using Microsoft.AspNetCore.Mvc;
using MaintenanceSheduleSystem.API.Contracts;
using MaintenanceSheduleSystem.Application.Services;
namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdministratorService _service;

        public AdminController(AdministratorService service)
        {
            _service = service;
        }
        [HttpPost("newAdministartor")]
        public async Task<IActionResult> CreateAdministrator(CreateAdministratorRequest request) 
        {
            var result = await _service.CreateAdministrator(request.surname, request.firstName, request.lastName, request.email, request.password);

            return Ok(result);
        }

    }
}
