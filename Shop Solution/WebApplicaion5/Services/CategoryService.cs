using WebApplication5.Models;

namespace WebApplication5.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        // Add any business logic/validation here before saving
        await _repository.AddAsync(category);
        return category;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        // Add any business logic/validation here before updating
        if (!await _repository.ExistsAsync(category.Id))
        {
            throw new KeyNotFoundException($"Category with ID {category.Id} not found.");
        }

        await _repository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        if (!await _repository.ExistsAsync(id))
        {
            throw new KeyNotFoundException($"Category with ID {id} not found.");
        }

        // Add any business logic/validation here before deleting (e.g., check for child categories)
        await _repository.DeleteAsync(id);
    }
}