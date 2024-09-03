using Microsoft.AspNetCore.Mvc;
using MaintenanceSheduleSystem.Application.Services;
namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestAPI : ControllerBase
    {
        private readonly UserService _userService;

        public TestAPI(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> UserCreate(string surname, string firstName, string lastName, string email, string password)
        {
           await _userService.AddAdministrator(surname, firstName, lastName, email, password);

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
