using StudentApi.Application.DTOs;

namespace StudentApi.Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(CreateUserDto dto);
}