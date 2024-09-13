using MaintenanceSheduleSystem.Application.Services;
using MaintenanceSheduleSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceSheduleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetAll()
        {
            
            var result = await _orderService.GetAllOrders();

            return Ok(result);
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
