using Demo_App.Implementation;
using Demo_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        public OrderController(IOrderService orderService)
        {
            _order = orderService;
        }

        [HttpGet]
        [Route("/GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _order.GetOrdersAsync());
        }

        [HttpGet]
        [Route("/GetOrderById/{id}")]
        public async Task<ActionResult<Order>> GetOrder([FromRoute] int id)
        {
            var order = await _order.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        [Route("/CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            var createdOrder = await _order.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPut]
        [Route("/UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, Order order)
        {
            var updated = await _order.UpdateOrderAsync(id, order);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("/DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var deleted = await _order.DeleteOrderAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
