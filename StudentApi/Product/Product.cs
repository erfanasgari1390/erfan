using StudentApi.Category;

namespace StudentApi.Product;

public class product
{
    

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public category Category { get; set; }
}