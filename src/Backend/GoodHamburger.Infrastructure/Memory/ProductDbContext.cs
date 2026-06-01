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

            var descriptionXBurger = "Beef, cheese, lettuce, tomato";
            var descriptionXEgg = "Beef, cheese, lettuce, tomato, egg";
            var descriptionXBacon = "Double beef, extra bacon, BBQ sauce";

            modelBuilder.Entity<Product>().HasData(
                new Product("X Burger", 5.00m, descriptionXBurger, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=300", CategoryProduct.Sandwich) { Id = 1 },
                new Product("X Egg", 4.50m, descriptionXEgg, "https://img.magnific.com/fotos-premium/hamburguer-suculento-com-ovo-sobre-um-fundo-preto_788242-1126.jpg", CategoryProduct.Sandwich) { Id = 2 },
                new Product("X Bacon", 7.00m, descriptionXBacon, "https://embutidosbonatti.ind.br/temp/BIN_57_V9Fb0BwK.jpg", CategoryProduct.Sandwich) { Id = 3 },
                new Product("Fries", 2.00m, "Crispy golden salted potatoes", "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=300", CategoryProduct.Fries) { Id = 4 },
                new Product("Soda", 2.50m, "Refreshing cold soda", "https://static.vecteezy.com/system/resources/previews/003/802/133/non_2x/soda-with-usa-flag-free-vector.jpg", CategoryProduct.Soda) { Id = 5 }
            );
        }
    }
}
