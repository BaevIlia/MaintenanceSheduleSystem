using Microsoft.AspNetCore.Mvc;
using MaintenanceSheduleSystem.Core.Models;
using MaintenanceSheduleSystem.Core.Interfaces;
namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestAPI : ControllerBase
    {
        private readonly IUserService _userService;

        public TestAPI(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("createUser")]
        public IActionResult UserCreate(string surname, string firstName, string lastName, string email, string password)
        {
            _userService.AddAdmin(surname, firstName, lastName, email, password);

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
