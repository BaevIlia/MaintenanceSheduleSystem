using MaintenanceSheduleSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet("orders")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder()
        {
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder() 
        {
            return Created();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrder() 
        {
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteOrder() 
        {
            return Ok();
        }
        
    }
}
