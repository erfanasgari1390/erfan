using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StudentApi.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _cache;
    public UserController(ApplicationDbContext context,IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] user user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        string cacheKey = $"user-{id}";

        if (!_cache.TryGetValue(cacheKey, out user cachedUser))
        {
            cachedUser = await _context.Users
                .Include(u => u.CartItems)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (cachedUser == null)
                return NotFound();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10)); 

            _cache.Set(cacheKey, cachedUser, cacheOptions);
        }

        return Ok(cachedUser);
    }
}