using MaintenanceSheduleSystem.Application.Services;
using MaintenanceSheduleSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            User result = await _userBaseService.GetById(Guid.Parse(id));

            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _userBaseService.Login(email, password);
            HttpContext.Response.Cookies.Append("myCookies", result);

            return Ok(result);
        }
        [Authorize]
        [HttpPost("logout")]
        public void Logout()
        {
            HttpContext.Response.Cookies.Delete("myCookies");

        }
        [Authorize]
        [HttpPatch("changePassword")]
        public async Task<IActionResult> ChangePassword(string userId, string newPassword) 
        {
            var result = await _userBaseService.ChangePassword(Guid.Parse(userId), newPassword);

            return Ok(result);
        }

        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfile(string id) 
        {
            
        }
    }
}
