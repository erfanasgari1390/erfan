namespace StudentApi.User;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<Cartitem> CartItems { get; set; } = new List<Cartitem>();

}