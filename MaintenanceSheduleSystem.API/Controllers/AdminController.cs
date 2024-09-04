using Microsoft.AspNetCore.Mvc;
using MaintenanceSheduleSystem.API.Contracts;
namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        public async Task<IActionResult> CreateAdministrator(CreateAdministratorRequest request) 
        {

        }

    }
}
