namespace WebApplication5.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public List<ProductPropertyDto> Properties { get; set; }
}