using GoodHamburger.Application.Interfaces;
using GoodHamburger.Application.Services;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Domain.Interfaces.Services;
using GoodHamburger.Domain.Services;
using GoodHamburger.Infrastructure.Repositories;

namespace GoodHamburger.API.Configurations
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionExtensions(this IServiceCollection services)
        {
            services.AddScoped<IMenuAppService, MenuAppService>();

            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
