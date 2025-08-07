using StudentApi.Domain.Entities;

namespace StudentApi.Application.Interfaces.Repositories;

public interface ICartItemRepository
{
    Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId);
    Task AddAsync(CartItem item);
    Task SaveChangesAsync();
}