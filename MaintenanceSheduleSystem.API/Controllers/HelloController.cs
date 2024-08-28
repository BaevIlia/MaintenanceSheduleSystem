using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("sayHello")]
        public async Task<IActionResult> SayHello() 
        {
            return Ok("Hello world");
        }
    }
}
