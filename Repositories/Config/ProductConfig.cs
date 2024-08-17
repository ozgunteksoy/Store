using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/images/1.jpeg", ProductName = "Computer", Price = 17_000, ShowCase = false },
                new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/2.jpeg", ProductName = "Keyboard", Price = 2_500, ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/3.jpeg", ProductName = "Monitor", Price = 8_000, ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/images/4.jpeg", ProductName = "Speaker", Price = 4_000, ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/images/5.jpeg", ProductName = "Mouse", Price = 1_500, ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/images/6.jpeg", ProductName = "Sci-Fiction", Price = 50, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/images/7.jpeg", ProductName = "Biography", Price = 150, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 2, ImageUrl = "/images/history.jpeg", ProductName = "History", Price = 120, ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 2, ImageUrl = "/images/dram.jpeg", ProductName = "Dram", Price = 100, ShowCase = true },
                new Product() { ProductId = 10, CategoryId = 2, ImageUrl = "/images/fear.jpeg", ProductName = "Fear", Price = 70, ShowCase = true }

            );
        }
    }
}