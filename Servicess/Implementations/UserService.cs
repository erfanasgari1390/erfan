using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using StudentApi.Application.DTOs;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Application.Interfaces.Services;
using StudentApi.Domain.Entities;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _repo.GetAllAsync();
        return users.Select(u => new UserDto { Id = u.Id, Username = u.Username });
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user == null ? null : new UserDto { Id = user.Id, Username = user.Username};
    }

    public async Task CreateAsync(UserDto dto)
    {
        var user = new User { Username = dto.Username };
        await _repo.CreateAsync(user);
    }

    public async Task UpdateAsync(int id, UserDto dto)
    {
        var user = new User { Id = id, Username = dto.Username };
        await _repo.UpdateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}