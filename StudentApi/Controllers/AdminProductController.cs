using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Product;

[ApiController]
[Route("api/[controller]")]
public class AdminProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    private bool IsAdmin(string username)
    {
        return username?.ToLower() == "عرفان";
    }

    [HttpPost("{username}")]
    public async Task<IActionResult> CreateProduct(string username, [FromBody] Product product)
    {
        if (!IsAdmin(username))
            return Unauthorized("دسترسی ندارید");

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPut("{username}/{id}")]
    public async Task<IActionResult> UpdateProduct(string username, int id, [FromBody] Product product)
    {
        if (!IsAdmin(username))
            return Unauthorized("دسترسی ندارید");

        var existing = await _context.Products.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.CategoryId = product.CategoryId;

        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    [HttpDelete("{username}/{id}")]
    public async Task<IActionResult> DeleteProduct(string username, int id)
    {
        if (!IsAdmin(username))
            return Unauthorized("دسترسی ندارید");

        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetAllProducts(string username)
    {
        if (!IsAdmin(username))
            return Unauthorized("دسترسی ندارید");

        var products = await _context.Products.Include(p => p.Category).ToListAsync();
        return Ok(products);
    }
}