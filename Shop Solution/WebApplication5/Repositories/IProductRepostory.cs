using WebApplication5.Models;

namespace WebApplication5.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetProductWithPropertiesAsync(int id);
}
