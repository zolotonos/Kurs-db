using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kurs_db.Models;

namespace Kurs_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public AnalyticsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/analytics/top-products
        // Цей метод виконує вимогу "Складні аналітичні запити"
        // Використовує: JOIN, GROUP BY, SUM, ORDER BY
        [HttpGet("top-products")]
        public async Task<ActionResult<List<ProductAnalyticsDto>>> GetTopSellingProducts()
        {
            var report = await _context.OrderItems
                .Include(oi => oi.Product) // Це JOIN з таблицею Product
                .GroupBy(oi => new { oi.ProductId, oi.Product.Name }) // Групуємо по товару
                .Select(g => new ProductAnalyticsDto
                {
                    ProductName = g.Key.Name,
                    TotalUnitsSold = g.Sum(oi => oi.Quantity), // Агрегатна функція SUM
                    TotalRevenue = g.Sum(oi => oi.Quantity * oi.UnitPrice) // Рахуємо виручку
                })
                .OrderByDescending(x => x.TotalRevenue) // Сортуємо: найприбутковіші зверху
                .Take(5) // Беремо топ-5
                .ToListAsync();

            return Ok(report);
        }
    }

    // DTO для звіту (щоб виводити гарний JSON)
    public class ProductAnalyticsDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int TotalUnitsSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}