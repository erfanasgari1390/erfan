namespace StudentApi.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}