using StudentApi.CartItem;

namespace StudentApi.User;

public class user
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<catitem> CartItems { get; set; } = new List<catitem>();

}