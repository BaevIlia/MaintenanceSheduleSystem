using MaintenanceSheduleSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserBaseController : ControllerBase
    {
        private readonly UserBaseService _userBaseService;

        public UserBaseController(UserBaseService userBaseService)
        {
            _userBaseService = userBaseService; 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById() 
        {
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password) 
        {
            var result = await _userBaseService.Login(email, password);

            return Ok(result);
        }
    }
}
