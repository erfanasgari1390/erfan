using Microsoft.EntityFrameworkCore;
using WebApplication5.DbContext;
using WebApplication5.Models;

namespace WebApplication5.Services;

public class ProductService : IProductService
{
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.ProductProperties)
                .ThenInclude(pp => pp.Property)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductProperties)
                .ThenInclude(pp => pp.Property)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

}