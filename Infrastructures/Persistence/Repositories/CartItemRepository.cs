using Microsoft.EntityFrameworkCore;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Domain.Entities;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Domain.Entities;
using YourProject.Infrastructure.Persistence;

public class CartItemRepository : ICartItemRepository
{
    private readonly ApplicationDbContext _context;
    public CartItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CartItem>> GetAllAsync() =>
        await _context.CartItems.ToListAsync();

    public async Task<CartItem> GetByIdAsync(int id) =>
        await _context.CartItems.FindAsync(id);

    public async Task AddAsync(CartItem item)
    {
        _context.CartItems.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CartItem item)
    {
        _context.CartItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item != null)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}