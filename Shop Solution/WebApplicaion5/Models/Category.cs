namespace WebApplication5.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? ParentId { get; set; }

    // Optional: Navigation property for parent/children relationships
    public Category Parent { get; set; }
    public ICollection<Category> Children { get; set; }
}

