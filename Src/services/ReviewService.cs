using Kurs_db.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs_db.Services
{
    public class ReviewService
    {
        private readonly ShopDbContext _context;

        public ReviewService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            // Валідація зовнішніх ключів перед вставкою
            var productExists = await _context.Products.AnyAsync(p => p.ProductId == review.ProductId);
            if (!productExists) 
                throw new KeyNotFoundException($"Product with ID {review.ProductId} not found.");

            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == review.CustomerId);
            if (!customerExists) 
                throw new KeyNotFoundException($"Customer with ID {review.CustomerId} not found.");

            review.ReviewId = Guid.NewGuid();
            review.CreatedAt = DateTime.UtcNow;
            
            // Очищуємо навігаційні властивості, щоб EF Core не намагався створити дублікати
            review.Product = null;
            review.Customer = null;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return review;
        }

        // Реалізація теми "JOINs" (Left Join з таблицею Customers)
        public async Task<List<Review>> GetReviewsByProductAsync(Guid productId)
        {
            return await _context.Reviews
                .AsNoTracking() // Оптимізація для читання
                .Where(r => r.ProductId == productId)
                .Include(r => r.Customer) 
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        // Реалізація теми "Aggregation Functions" (AVG)
        public async Task<double> GetAverageRatingAsync(Guid productId)
        {
            try
            {
                return await _context.Reviews
                    .Where(r => r.ProductId == productId)
                    .AverageAsync(r => r.Rating);
            }
            catch (InvalidOperationException)
            {
                return 0; // Якщо відгуків немає
            }
        }

        // Реалізація теми "GROUP BY": Розподіл оцінок (скільки 5-рок, 4-ок тощо)
        public async Task<Dictionary<int, int>> GetRatingDistributionAsync(Guid productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == productId)
                .GroupBy(r => r.Rating)
                .Select(g => new { Rating = g.Key, Count = g.Count() })
                .ToDictionaryAsync(k => k.Rating, v => v.Count);
        }
    }
}