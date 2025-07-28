namespace WebApplication5.Models;

public class Property
{
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
}
    