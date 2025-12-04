using Microsoft.EntityFrameworkCore;
using StudentApi.CartItem;
using StudentApi.Category;
using StudentApi.Product;
using StudentApi.User;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<category> Categories { get; set; }
    public DbSet<product> Products { get; set; }
    public DbSet<user> Users { get; set; }
    public DbSet<catitem> Cartitems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<product>()
            .HasOne<category>(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<catitem>()
            .HasOne(ci => ci.User)
            .WithMany(u => u.CartItems)
            .HasForeignKey(ci => ci.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<catitem>()
            .HasOne(ci => ci. Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}