using StudentApi.Application.DTOs;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Application.Interfaces.Services;
using Domain.Entities;
using StudentApi.Application.DTOs;
using StudentApi.Application.Interfaces.Repositories;
using StudentApi.Application.Interfaces.Services;
using StudentApi.Domain.Entities;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _repo.GetAllAsync();
        return categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name });
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _repo.GetByIdAsync(id);
        return category == null ? null : new CategoryDto { Id = category.Id, Name = category.Name };
    }

    public async Task CreateAsync(CategoryDto dto)
    {
        var category = new Category { Name = dto.Name };
        await _repo.CreateAsync(category);
    }

    public async Task UpdateAsync(int id, CategoryDto dto)
    {
        var category = new Category { Id = id, Name = dto.Name };
        await _repo.UpdateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}