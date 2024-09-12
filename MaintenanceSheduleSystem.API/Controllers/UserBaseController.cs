using MaintenanceSheduleSystem.Application.Services;
using MaintenanceSheduleSystem.Core.Dto.UserBaseDto_s;
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
        public async Task<IActionResult> Login(LoginDto request)
        {
            if (String.IsNullOrWhiteSpace(request.email) || String.IsNullOrWhiteSpace(request.password)) 
            {
                return BadRequest("Логин или пароль пуст");
            }
            if (!request.email.EndsWith("@domain.ru")) 
            {
                return BadRequest("Почта с таким доменом недопустима");
            }
            string token = await _userBaseService.Login(request.email, request.password);
            HttpContext.Response.Cookies.Append("myCookies", token);

            var result = await _userBaseService.GetByEmail(request.email);
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
        public async Task<IActionResult> ChangePassword(ChangePasswordDto request) 
        {
            var result = await _userBaseService.ChangePassword(Guid.Parse(request.userId), request.newPassword);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok(result);
        }
        

        
    }
}
