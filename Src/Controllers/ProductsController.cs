using Microsoft.AspNetCore.Mvc;
using Kurs_db.Services;
using Kurs_db.Models;

namespace Kurs_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var created = await _productService.AddProductAsync(product);
            return Ok(created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.SoftDeleteProductAsync(id);
            return NoContent();
        }

        // Новий ендпоінт для 2-го студента
        [HttpPut("bulk-raise-price")]
        public async Task<IActionResult> RaisePrices(decimal percent)
        {
            await _productService.BulkUpdatePriceAsync(percent);
            return Ok(new { Message = "Ціни успішно піднято" });
        }
    }
}