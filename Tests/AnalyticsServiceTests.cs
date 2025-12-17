using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Kurs_db.Models;
using Kurs_db.Services;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class AnalyticsServiceTests
    {
        // Допоміжний метод для створення тестової бази
        private ShopDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return new ShopDbContext(options);
        }

        [Fact]
        public async Task GetTopProductsAsync_Should_Return_Correct_Revenue()
        {
            // 1. Arrange (Підготовка даних)
            using var context = GetInMemoryDbContext();

            var product = new Product { ProductId = Guid.NewGuid(), Name = "Super Phone", Price = 1000, StockQuantity = 10 };
            context.Products.Add(product);

            var order = new Order { OrderId = Guid.NewGuid(), Status = "Completed" };
            context.Orders.Add(order);

            // Додаємо 2 продажі цього товару
            context.OrderItems.Add(new OrderItem { OrderItemId = Guid.NewGuid(), OrderId = order.OrderId, ProductId = product.ProductId, Quantity = 2, UnitPrice = 1000 });
            
            await context.SaveChangesAsync();

            var service = new AnalyticsService(context);

            // 2. Act (Виконання)
            var result = await service.GetTopProductsAsync();

            // 3. Assert (Перевірка)
            Assert.NotEmpty(result);
            
            // Використовуємо Reflection, бо результат - це анонімний об'єкт (object)
            var firstItem = result[0];
            var revenueProperty = firstItem.GetType().GetProperty("TotalRevenue");
            var revenueValue = (decimal)revenueProperty!.GetValue(firstItem)!;

            Assert.Equal(2000, revenueValue); // 2 шт * 1000 грн = 2000
        }
    }
}