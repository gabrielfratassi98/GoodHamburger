using GoodHamburger.Infrastructure.Memory;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.API.Configurations
{
    public static class DbContextConfiguration
    {
        public static void DbContextsExtensions(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseInMemoryDatabase("GoodHamburgerDb"));

            services.AddDbContext<OrderDbContext>(options =>
                options.UseInMemoryDatabase("GoodHamburgerDb"));
        }
    }
}
