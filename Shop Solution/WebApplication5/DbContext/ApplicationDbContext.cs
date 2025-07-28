using Microsoft.EntityFrameworkCore;
using WebApplication5.Mappings;
using WebApplication5.Models;

namespace WebApplication5.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<ProductProperty> ProductProperties { get; set; }
      public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Children)
            .WithOne(c => c.Parent)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false) // ParentId is nullable
            .OnDelete(DeleteBehavior.Restrict); // Prevent cyclic deletion issues, or choose Cascade
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());
    }
}
