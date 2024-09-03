using Microsoft.AspNetCore.Mvc;
using MaintenanceSheduleSystem.Core.Models;
namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestAPI : ControllerBase
    {
        [HttpPost("createUser")]
        public IActionResult UserCreate()
        {
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpGet("role")]
        public IActionResult CheckRole() 
        {
            return Ok();
        }
    }
}
