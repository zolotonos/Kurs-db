using Kurs_db.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs_db.Services
{
    public class AnalyticsService
    {
        private readonly ShopDbContext _context;

        public AnalyticsService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetTopProductsAsync()
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.Product != null)
                .GroupBy(oi => new { oi.ProductId, ProductName = oi.Product!.Name })
                .Select(g => new 
                {
                    ProductName = g.Key.ProductName,
                    TotalRevenue = g.Sum(oi => oi.Quantity * oi.UnitPrice)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .Take(5)
                .ToListAsync<object>();
        }

        public async Task<List<object>> GetBestCustomersAsync()
        {
            return await _context.Orders
                .Where(o => o.Status == "Completed" && o.Customer != null)
                .Include(o => o.Customer)
                .GroupBy(o => new { o.Customer!.FirstName, o.Customer!.LastName, o.Customer!.Email })
                .Select(g => new 
                {
                    Customer = $"{g.Key.FirstName} {g.Key.LastName}",
                    Email = g.Key.Email,
                    TotalSpent = g.Sum(o => o.TotalAmount),
                    OrdersCount = g.Count()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ToListAsync<object>();
        }
    }
}