using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministratorController : ControllerBase
    {
        public async Task<IActionResult> CreatePlannerEngineer() 
        {
            return Ok();
        }

        public async Task<IActionResult> CreateServiceman() 
        {
            return Ok();
        }
    }
}
