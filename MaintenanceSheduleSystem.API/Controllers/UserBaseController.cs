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
            if (id is null) 
            {
                return BadRequest("Идентификатор отсутствует");
            }
            User result = await _userBaseService.GetById(Guid.Parse(id));

            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password)) 
            {
                return BadRequest("Логин или пароль пуст");
            }
            string token = await _userBaseService.Login(email, password);
            HttpContext.Response.Cookies.Append("myCookies", token);

            var result = await _userBaseService.GetByEmail(email);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<string> Logout()
        {
            try
            {
                HttpContext.Response.Cookies.Delete("myCookies");
            }
            catch(Exception ex) 
            {
                return $"Ошибка выхода из профиля - {ex.Message}";
            };
            return "Успешно";
        }
        [Authorize]
        [HttpPatch("changePassword")]
        public async Task<IActionResult> ChangePassword(string userId, string newPassword) 
        {
            var result = await _userBaseService.ChangePassword(Guid.Parse(userId), newPassword);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok(result);
        }
        

        
    }
}
