using GoodHamburger.Web.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoodHamburger.Web.Services
{
    public interface IOrderService
    {
        Task<ApiResponse<List<OrderModel>>> GetAllOrders();
        Task<ApiResponse<OrderModel>> GetOrder(long id);
        Task<ApiResponse> FinishOrder(long id);
        Task<ApiResponse<OrderModel>> DeleteProductOrder(int idProduct, long id);
        Task<ApiResponse<OrderModel>> AddProductOrder(int idProduct, long id);
        Task<ApiResponse<OrderModel>> Delete(long id);
    }

    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;

        public OrderService(HttpClient http) => _http = http;

        public async Task<ApiResponse<List<OrderModel>>> GetAllOrders()
        {
            var response = await _http.GetAsync($"orders");

            return await response.Content.ReadFromJsonAsync<ApiResponse<List<OrderModel>>>();
        }

        public async Task<ApiResponse<OrderModel>> GetOrder(long id)
        {
            var response = await _http.GetAsync($"orders/{id}");

            var order = await response.Content.ReadFromJsonAsync<ApiResponse<OrderModel>>();

            return order;
        }

        public async Task<ApiResponse> FinishOrder(long id)
        {
            var response = await _http.DeleteAsync($"orders/{id}/finish");
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }

        public async Task<ApiResponse<OrderModel>> DeleteProductOrder(int idProduct, long id)
        {
            var response = await _http.DeleteAsync($"orders/{id}/products/{idProduct}");

            return await response.Content.ReadFromJsonAsync<ApiResponse<OrderModel>>();
        }

        public async Task<ApiResponse<OrderModel>> AddProductOrder(int idProduct, long id)
        {
            HttpResponseMessage response;

            var payload = new { IdsProducts = new List<int> { idProduct } };

            if (id == 0)
            {
                response = await _http.PostAsJsonAsync("orders", payload);
            }
            else
            {
                response = await _http.PostAsJsonAsync($"orders/{id}/products", payload);
            }

            return await response.Content.ReadFromJsonAsync<ApiResponse<OrderModel>>();
        }

        public async Task<ApiResponse<OrderModel>> Delete(long id)
        {
            var response = await _http.DeleteAsync($"orders/{id}");
            return await response.Content.ReadFromJsonAsync<ApiResponse<OrderModel>>();
        }
    }
}
