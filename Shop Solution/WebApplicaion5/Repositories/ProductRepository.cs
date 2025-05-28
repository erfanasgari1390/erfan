using Microsoft.EntityFrameworkCore;
using WebApplication5.DbContext;
using WebApplication5.Models;

namespace WebApplication5.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context) {}

    public async Task<Product?> GetProductWithPropertiesAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductProperties)
            .ThenInclude(pp => pp.Property)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
