using StudentApi.Product;
using StudentApi.User;

namespace StudentApi.CartItem;

public class catitem
{
    
    public int Id { get; set; }

    public int UserId { get; set; }
    public user User { get; set; }

    public int ProductId { get; set; }
    public product Product { get; set; }

    public int Quantity { get; set; }
}