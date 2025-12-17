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

        // Тут ми отримуємо наш Сервіс через конструктор
        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/orders/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                // Перетворюємо список товарів у словник, який чекає наш Сервіс
                var productsDict = request.Items.ToDictionary(x => x.ProductId, x => x.Quantity);

                // Викликаємо складну логіку створення (Транзакція, Валідація, Списання)
                var order = await _orderService.CreateOrderAsync(
                    request.CustomerId,
                    request.AddressId,
                    productsDict
                );

                return Ok(new { Message = "Замовлення успішно створено!", OrderId = order.OrderId });
            }
            catch (Exception ex)
            {
                // Якщо щось пішло не так (нема товару, помилка бази) - повертаємо помилку
                return BadRequest(new { Error = ex.Message });
            }
        }

        // === НОВИЙ МЕТОД (UPDATE) ===
        // PATCH: api/orders/{id}/status
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

    // Новий клас для запиту на зміну статусу
    public class UpdateStatusRequest
    {
        public string Status { get; set; } = string.Empty;
    }
}