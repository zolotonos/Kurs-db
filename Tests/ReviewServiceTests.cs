using Kurs_db.Models;
using Kurs_db.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class ReviewServiceTests
    {
        private ShopDbContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ShopDbContext(options);
        }

        [Fact]
        public async Task AddReview_Success_WhenDataIsValid()
        {
            using var context = GetInMemoryContext();
            var product = new Product { ProductId = Guid.NewGuid(), Name = "Test Phone", Price = 1000, StockQuantity = 10 };
            var customer = new Customer { CustomerId = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "test@test.com" };
            
            context.Products.Add(product);
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var service = new ReviewService(context);
            var newReview = new Review
            {
                ProductId = product.ProductId,
                CustomerId = customer.CustomerId,
                Rating = 5,
                Comment = "Excellent!"
            };

            var result = await service.AddReviewAsync(newReview);

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.ReviewId);
            Assert.Equal(1, await context.Reviews.CountAsync());
        }

        [Fact]
        public async Task AddReview_ThrowsException_WhenProductMissing()
        {
            using var context = GetInMemoryContext();
            var service = new ReviewService(context);
            
            var badReview = new Review
            {
                ProductId = Guid.NewGuid(), 
                CustomerId = Guid.NewGuid(),
                Rating = 5
            };

            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.AddReviewAsync(badReview));
        }

        [Fact]
        public async Task GetRatingDistribution_CalculatesCorrectly()
        {
            using var context = GetInMemoryContext();
            var pid = Guid.NewGuid();
            var cid = Guid.NewGuid();

            // Додаємо: дві 5-ки і одну 4-ку
            context.Reviews.AddRange(
                new Review { ReviewId = Guid.NewGuid(), ProductId = pid, CustomerId = cid, Rating = 5 },
                new Review { ReviewId = Guid.NewGuid(), ProductId = pid, CustomerId = cid, Rating = 5 },
                new Review { ReviewId = Guid.NewGuid(), ProductId = pid, CustomerId = cid, Rating = 4 }
            );
            await context.SaveChangesAsync();

            var service = new ReviewService(context);

            var result = await service.GetRatingDistributionAsync(pid);

            // Очікуємо: Key 5 -> Value 2, Key 4 -> Value 1
            Assert.True(result.ContainsKey(5));
            Assert.Equal(2, result[5]);
            Assert.Equal(1, result[4]);
        }
    }
}