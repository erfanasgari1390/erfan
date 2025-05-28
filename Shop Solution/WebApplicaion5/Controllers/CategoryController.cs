using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebApplication5.DbContext;
using WebApplication5.Models;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IDistributedCache _cache;

    public CategoryController(ApplicationDbContext context, IDistributedCache cache)
    {
        _context = context;
        _cache = cache;
    }

    // GET all categories with Redis cache
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        string cacheKey = "categoryList";
        string cachedData = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedData))
        {
            var cachedCategories = JsonSerializer.Deserialize<List<Category>>(cachedData);
            return Ok(cachedCategories);
        }

        var categories = await _context.Categories.ToListAsync();

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        };

        string serializedData = JsonSerializer.Serialize(categories);
        await _cache.SetStringAsync(cacheKey, serializedData, options);

        return Ok(categories);
    }

    // GET by ID (optional cache)
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();
        return Ok(category);
    }

    // POST - Create (Clear Cache)
    [HttpPost]
    public async Task<ActionResult<Category>> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        await _cache.RemoveAsync("categoryList");

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    // PUT - Update (Clear Cache)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest();

        _context.Entry(category).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            await _cache.RemoveAsync("categoryList"); 
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE (Clear Cache)
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        await _cache.RemoveAsync("categoryList"); 

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }
}
