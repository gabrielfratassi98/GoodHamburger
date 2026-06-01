using GoodHamburger.Web.Services;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Http;

namespace GoodHamburger.Web.Configurations
{
    public static class HttpClientExtensions
    {
        public static void HttpExtensions(this IServiceCollection services)
        {
            services.AddHttpClient<IMenuService, MenuService>(client =>
            {
                client.BaseAddress = new Uri(ApiConfig.BaseUrl);
            });
        }
    }
}
