using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
        public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options): base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() {ProductId=1,ProductName="Computer",Price=17_000},
                new Product() {ProductId=2,ProductName="Keyboard",Price=2_500},
                new Product() {ProductId=3,ProductName="Monitor",Price=8_000},
                new Product() {ProductId=4,ProductName="Speaker",Price=4_000},
                new Product() {ProductId=5,ProductName="Mouse",Price=1_500}
            );
        }
    }
}
