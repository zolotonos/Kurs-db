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

        public async Task<List<TopProductDto>> GetTopProductsAsync()
        {
            var query = _context.OrderItems
                .Include(oi => oi.Product)
                .Include(oi => oi.Order)
                .Where(oi => oi.Product != null && oi.Order != null && oi.Order.Status == "Completed");

            var grouped = query.GroupBy(oi => new { oi.ProductId, ProductName = oi.Product!.Name });

            var result = grouped.Select(g => new TopProductDto
            {
                ProductName = g.Key.ProductName,
                TotalRevenue = g.Sum(oi => oi.Quantity * oi.UnitPrice)
            });

            return await result
                .OrderByDescending(x => x.TotalRevenue)
                .Take(5)
                .ToListAsync();
        }

        public async Task<List<BestCustomerDto>> GetBestCustomersAsync()
        {
            return await _context.Orders
                .Where(o => o.Status == "Completed" && o.Customer != null)
                .Include(o => o.Customer)
                .GroupBy(o => new { o.Customer!.FirstName, o.Customer!.LastName, o.Customer!.Email })
                .Select(g => new BestCustomerDto 
                {
                    CustomerName = $"{g.Key.FirstName} {g.Key.LastName}",
                    Email = g.Key.Email,
                    TotalSpent = g.Sum(o => o.TotalAmount),
                    OrdersCount = g.Count()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ToListAsync();
        }
    }
    public class TopProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
    }

    public class BestCustomerDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal TotalSpent { get; set; }
        public int OrdersCount { get; set; }
    }
}