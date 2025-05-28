namespace WebApplication5.Models;

public class ProductProperty
{
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public string Value { get; set; } 
}