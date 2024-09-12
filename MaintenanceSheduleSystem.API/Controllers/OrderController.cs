using MaintenanceSheduleSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder() 
        {
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder() 
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder() 
        {
            return Ok();
        }
        
    }
}
