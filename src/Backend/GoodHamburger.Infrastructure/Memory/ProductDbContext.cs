using GoodHamburger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.Memory
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product("X-Burger", 5.00m, CategoryProduct.Sandwich) { Id = 1 },
                new Product("X-Egg", 4.50m, CategoryProduct.Sandwich) { Id = 2 },
                new Product("X-Bacon", 7.00m, CategoryProduct.Sandwich) { Id = 3 },
                new Product("Fries", 2.00m, CategoryProduct.Fries) { Id = 4 },
                new Product("Soda", 2.50m, CategoryProduct.Soda) { Id = 5 }
            );
        }
    }
}
