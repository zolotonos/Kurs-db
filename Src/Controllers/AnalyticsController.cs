using Microsoft.AspNetCore.Mvc;
using Kurs_db.Services;

namespace Kurs_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsService _analyticsService;

        public AnalyticsController(AnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("top-products")]
        public async Task<IActionResult> GetTopProducts()
        {
            return Ok(await _analyticsService.GetTopProductsAsync());
        }

        [HttpGet("best-customers")]
        public async Task<IActionResult> GetBestCustomers()
        {
            return Ok(await _analyticsService.GetBestCustomersAsync());
        }
    }
}