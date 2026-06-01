using GoodHamburger.Web.Models;
using System.Net.Http.Json;

namespace GoodHamburger.Web.Services
{
    public interface IMenuService
    {
        Task<ApiResponse<MenuData>> GetMenu();
    }

    public class MenuService : IMenuService
    {
        private readonly HttpClient _http;

        public MenuService(HttpClient http) => _http = http;

        public async Task<ApiResponse<MenuData>> GetMenu()
        {
            var response = await _http.GetAsync("menus");
            response.EnsureSuccessStatusCode();
            var menu = await response.Content.ReadFromJsonAsync<ApiResponse<MenuData>>();
            return menu;
        }
    }
}
