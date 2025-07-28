namespace WebApplication5.Models;

public class Product
{
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Category CategoryId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
}