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
    }

    // Це спеціальні класи (DTO), щоб зручно приймати дані від клієнта
    // Вони описують, який JSON ми чекаємо
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
}