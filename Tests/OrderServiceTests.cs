using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics; 
using Kurs_db.Models;
using Kurs_db.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class OrderServiceTests
    {
        private ShopDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new ShopDbContext(options);
            return context;
        }

        [Fact]
        public async Task CreateOrderAsync_Should_ReduceStock_And_CalculateTotal()
        {
            using var context = GetInMemoryDbContext();
            
            var customerId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            
            context.Customers.Add(new Customer { CustomerId = customerId, FirstName = "Test", LastName = "User", Email = "test@test.com", Phone = "123" });
            context.Products.Add(new Product { ProductId = productId, Name = "Laptop", Price = 1000, StockQuantity = 10, IsDeleted = false });
            await context.SaveChangesAsync();

            var service = new OrderService(context);
            
            var requestItems = new Dictionary<Guid, int>
            {
                { productId, 2 }
            };

            var order = await service.CreateOrderAsync(customerId, Guid.NewGuid(), requestItems);

            Assert.NotNull(order);
            Assert.Equal(2000, order.TotalAmount);
            
            var productInDb = await context.Products.FindAsync(productId);
            Assert.NotNull(productInDb);
            Assert.Equal(8, productInDb!.StockQuantity);
        }

        [Fact]
        public async Task CreateOrderAsync_Should_Fail_If_NotEnoughStock()
        {
            using var context = GetInMemoryDbContext();
            var customerId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            context.Customers.Add(new Customer { CustomerId = customerId, FirstName = "Test", LastName = "User", Email = "test@test.com", Phone="123" });
            context.Products.Add(new Product { ProductId = productId, Name = "Laptop", Price = 1000, StockQuantity = 5, IsDeleted = false });
            await context.SaveChangesAsync();

            var service = new OrderService(context);

            var requestItems = new Dictionary<Guid, int>
            {
                { productId, 10 }
            };

            await Assert.ThrowsAsync<Exception>(async () => 
            {
                await service.CreateOrderAsync(customerId, Guid.NewGuid(), requestItems);
            });
        }
    }
}