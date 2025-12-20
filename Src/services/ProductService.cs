using Kurs_db.Models;
using Microsoft.EntityFrameworkCore;

namespace Kurs_db.Services
{
    public class ProductService
    {
        private readonly ShopDbContext _context;

        public ProductService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync(int offset, int limit)
        {
            return await _context.Products
                .Where(p => p.IsDeleted == false)
                .OrderBy(p => p.Name)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            product.ProductId = Guid.NewGuid();
            product.IsDeleted = false;
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            
            if (product == null) return false;

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}