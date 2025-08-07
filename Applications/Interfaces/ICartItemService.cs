using StudentApi.Application.DTOs;

namespace StudentApi.Application.Interfaces.Services;

public interface ICartItemService
{
    Task<IEnumerable<CartItemDto>> GetByUserIdAsync(int userId);
    Task<CartItemDto> AddToCartAsync(CreateCartItemDto dto);
}