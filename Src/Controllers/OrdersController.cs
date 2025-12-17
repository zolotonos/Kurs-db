using Microsoft.AspNetCore.Mvc;
using Kurs_db.Services;
using Kurs_db.Models;

namespace Kurs_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var productsDict = request.Items.ToDictionary(x => x.ProductId, x => x.Quantity);

                var order = await _orderService.CreateOrderAsync(
                    request.CustomerId,
                    request.AddressId,
                    productsDict
                );

                return Ok(new { Message = "Замовлення успішно створено!", OrderId = order.OrderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStatusRequest request)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(id, request.Status);
                return Ok(new { Message = "Статус оновлено успішно" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }

    // === DTO КЛАСИ ===

    public class CreateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public List<OrderItemRequest> Items { get; set; } = new();
    }

    public class OrderItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateStatusRequest
    {
        public string Status { get; set; } = string.Empty;
    }
}