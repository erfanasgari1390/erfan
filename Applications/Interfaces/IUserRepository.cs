using StudentApi.Domain.Entities;

namespace StudentApi.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}