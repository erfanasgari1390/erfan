using StudentApi.Product;

namespace StudentApi.Category;

public class category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<product> Products { get; set; } = new List<product>(); 
}