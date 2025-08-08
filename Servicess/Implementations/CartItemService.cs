using StudentApi.Application.DTOs;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Application.Interfaces.Services;
using Domain.Entities;
using StudentApi.Application.DTOs;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Application.Interfaces.Services;
using StudentApi.Domain.Entities;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _repo;

    public CartItemService(ICartItemRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<CartItemDto>> GetAllAsync()
    {
        var cartItems = await _repo.GetAllAsync();
        return cartItems.Select(c => new CartItemDto
        {
            Id = c.Id,
            ProductId = c.ProductId,
            Quantity = c.Quantity,
            UserId = c.UserId
        });
    }

    public async Task<CartItemDto?> GetByIdAsync(int id)
    {
        var cartItem = await _repo.GetByIdAsync(id);
        return cartItem == null ? null : new CartItemDto
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            Quantity = cartItem.Quantity,
            UserId = cartItem.UserId
        };
    }

    public async Task CreateAsync(CartItemDto dto)
    {
        var cartItem = new CartItem
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            UserId = dto.UserId
        };
        await _repo.CreateAsync(cartItem);
    }

    public async Task UpdateAsync(int id, CartItemDto dto)
    {
        var cartItem = new CartItem
        {
            Id = id,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            UserId = dto.UserId
        };
        await _repo.UpdateAsync(cartItem);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}