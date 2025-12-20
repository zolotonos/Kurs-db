using Microsoft.AspNetCore.Mvc;
using Kurs_db.Models;
using Kurs_db.Services;

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
        public async Task<IActionResult> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            int skip = (page - 1) * pageSize;

            var products = await _productService.GetProductsAsync(skip, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            
            if (product == null) 
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return Ok(createdProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var success = await _productService.DeleteProductAsync(id);
            
            if (!success) 
                return NotFound();

            return NoContent();
        }
    }
}