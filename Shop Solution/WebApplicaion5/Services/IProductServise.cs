using WebApplication5.Models;

namespace WebApplication5.Services;

public interface IProductService
{
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);

}