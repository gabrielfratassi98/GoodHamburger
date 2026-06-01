using GoodHamburger.Web.Models;
using System.Net.Http.Json;

namespace GoodHamburger.Web.Services
{
    public interface IMenuService
    {
        Task<MenuData?> GetMenu();
    }

    public class MenuService : IMenuService
    {
        private readonly HttpClient _http;

        public MenuService(HttpClient http) => _http = http;

        public async Task<MenuData?> GetMenu()
        {
            var response = await _http.GetFromJsonAsync<MenuApiResponse>("menus");
            return response?.Data?.FirstOrDefault();
        }
    }
}
