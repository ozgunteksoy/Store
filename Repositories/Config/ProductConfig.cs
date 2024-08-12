using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();
            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 17_000 },
                new Product() { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", Price = 2_500 },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Monitor", Price = 8_000 },
                new Product() { ProductId = 4, CategoryId = 2, ProductName = "Speaker", Price = 4_000 },
                new Product() { ProductId = 5, CategoryId = 2, ProductName = "Mouse", Price = 1_500 },
                new Product() { ProductId = 6, CategoryId = 1, ProductName = "Sci-Fiction", Price = 50 },
                new Product() { ProductId = 7, CategoryId = 1, ProductName = "Biography", Price = 150 }

            );
        }
    }
}