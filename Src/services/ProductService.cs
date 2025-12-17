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

        // 1. GET (Простий)
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Where(p => p.IsDeleted == false) // ВИПРАВЛЕНО: Було !p.IsDeleted
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        // 2. CREATE (Простий, але через сервіс)
        public async Task<Product> AddProductAsync(Product product)
        {
            product.ProductId = Guid.NewGuid();
            product.IsDeleted = false;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // 3. DELETE (Soft Delete - Реалізовано одногрупником, перенесено сюди)
        public async Task SoftDeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        // 4. UPDATE (Сценарій 2-го студента: Масове подорожчання)
        // Вимога: "Оновлення кількох сутностей + транзакція"
        public async Task BulkUpdatePriceAsync(decimal percentage)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try 
            {
                var products = await _context.Products.ToListAsync();
                foreach(var p in products)
                {
                    p.Price = p.Price * (1 + (percentage / 100));
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch 
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}