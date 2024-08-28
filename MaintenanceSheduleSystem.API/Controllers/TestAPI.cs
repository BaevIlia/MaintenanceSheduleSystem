using Microsoft.AspNetCore.Mvc;
using MaintenanceSheduleSystem.Core.Models;
namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestAPI : ControllerBase
    {
        [HttpGet("hello")]
        public async Task<IActionResult> SayHello() 
        {
            return Ok("Hello world");
        }
        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin(string email, string password, string surname, string firstName, string lastName, string ownAcceptKey) 
        {
            User administrator = Administrator.Create(Guid.NewGuid(), email, password, new FullName(surname, firstName, lastName), ownAcceptKey);
            return Ok(administrator);
        }
        [HttpPost("createPlanner")]
        public async Task<IActionResult> CreatePlanner(string email, string password, string surname, string firstName, string lastName)
        {
            User administrator = PlannerEngineer.Create(Guid.NewGuid(), email, password, new FullName(surname, firstName, lastName));
            return Ok(administrator);
        }
        [HttpPost("createService")]
        public async Task<IActionResult> CreateService(string email, string password, string surname, string firstName, string lastName)
        {
            User administrator = ServicePersonal.Create(Guid.NewGuid(), email, password, new FullName(surname, firstName, lastName), null);
            return Ok(administrator);
        }

    }
}
