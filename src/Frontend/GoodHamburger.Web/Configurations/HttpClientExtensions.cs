using GoodHamburger.Web.Services;

namespace GoodHamburger.Web.Configurations
{
    public static class HttpClientExtensions
    {
        public static void HttpExtensions(this IServiceCollection services)
        {
            string baseUri = ApiConfig.BaseUrl;

            services.AddHttpClient<IMenuService, MenuService>(client =>
            {
                client.BaseAddress = new Uri(baseUri);
            });

            services.AddHttpClient<IOrderService, OrderService>(client =>
            {
                client.BaseAddress = new Uri(baseUri);
            });
        }
    }
}
