using Kurs_db.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs_db.Services
{
    public class OrderService
    {
        private readonly ShopDbContext _context;

        public OrderService(ShopDbContext context)
        {
            _context = context;
        }

        // Цей метод створює замовлення, додає товари і списує їх зі складу
        // Все це відбувається в одній транзакції (вимога методички)
        public async Task<Models.Order> CreateOrderAsync(Guid customerId, Guid addressId, Dictionary<Guid, int> productsWithQuantity)
        {
            // 1. Починаємо транзакцію
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Перевірка, чи існує клієнт
                var customer = await _context.Customers.FindAsync(customerId);
                if (customer == null) throw new Exception("Клієнта не знайдено");

                // 2. Створюємо "шапку" замовлення
                var order = new Models.Order
                {
                    OrderId = Guid.NewGuid(),
                    CustomerId = customerId,
                    AddressId = addressId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Pending", // Статус за замовчуванням
                    TotalAmount = 0
                };

                _context.Orders.Add(order);
                decimal totalAmount = 0;

                // 3. Проходимося по списку товарів
                foreach (var item in productsWithQuantity)
                {
                    var productId = item.Key;
                    var quantity = item.Value;

                    var product = await _context.Products.FindAsync(productId);

                    if (product == null)
                        throw new Exception($"Товар {productId} не знайдено");

                    // ВАЛІДАЦІЯ: Чи вистачає товару на складі?
                    if (product.StockQuantity < quantity)
                        throw new Exception($"Недостатньо товару '{product.Name}' на складі. Доступно: {product.StockQuantity}");

                    // Зменшуємо склад
                    product.StockQuantity -= quantity;

                    // Рахуємо суму
                    var lineTotal = product.Price * quantity;
                    totalAmount += lineTotal;

                    // Додаємо запис в OrderItem
                    var orderItem = new OrderItem
                    {
                        OrderItemId = Guid.NewGuid(),
                        OrderId = order.OrderId,
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = product.Price
                    };
                    _context.OrderItems.Add(orderItem);
                }

                order.TotalAmount = totalAmount;
                
                // 4. Зберігаємо всі зміни в БД
                await _context.SaveChangesAsync();

                // 5. Підтверджуємо транзакцію (якщо дійшли сюди - все ок)
                await transaction.CommitAsync();

                return order;
            }
            catch (Exception)
            {
                // Якщо була помилка - скасовуємо все
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}