using Domain.Entities;
using StudentApi.Domain.Entities;

namespace StudentApi.Application.Interfaces.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task SaveChangesAsync();
}