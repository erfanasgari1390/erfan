using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication5.Models;

namespace WebApplication5.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(p => p.ProductProperties)
                .WithOne(pp => pp.Product)
                .HasForeignKey(pp => pp.ProductId);
            entity.HasOne(p => p.CategoryId).WithMany().HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.Property(p => p.ShortDescription).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Description).IsRequired(false).HasMaxLength(700);
        });

        //Property
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(p => p.ProductProperties)
                .WithOne(pp => pp.Property)
                .HasForeignKey(pp => pp.PropertyId);
        });

        //ProductProperty
        modelBuilder.Entity<ProductProperty>(entity =>
        {
            entity.HasKey(pp => new { pp.ProductId, pp.PropertyId });

            entity.Property(pp => pp.Value)
                .IsRequired()
                .HasMaxLength(200);
        });
    }

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        throw new NotImplementedException();
    }
}

    