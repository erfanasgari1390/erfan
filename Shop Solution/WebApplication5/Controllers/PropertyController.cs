using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.DbContext;
using WebApplication5.Models;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PropertyController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET All Properties with ResponseCache
    [HttpGet]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)] 
    public async Task<ActionResult<IEnumerable<Property>>> GetAll()
    {
        var properties = await _context.Properties.ToListAsync();
        return Ok(properties);
    }

    // GET by ID with ResponseCache
    [HttpGet("{id}")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)] 
    public async Task<ActionResult<Property>> GetById(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
            return NotFound();

        return Ok(property);
    }

    // POST 
    [HttpPost]
    public async Task<ActionResult<Property>> Create(Property property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = property.Id }, property);
    }

    // PUT 
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Property property)
    {
        if (id != property.Id)
            return BadRequest();

        _context.Entry(property).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PropertyExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
            return NotFound();

        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PropertyExists(int id)
    {
        return _context.Properties.Any(e => e.Id == id);
    }
}
