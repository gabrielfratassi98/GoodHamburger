using GoodHamburger.API.Mapper;
using GoodHamburger.API.Models.Response;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers
{
    [ApiController]
    [Route("api/menus")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuAppService _menuAppService;
        private readonly IProductAppService _productAppService;

        public MenuController(IMenuAppService menuAppService, IProductAppService productAppService)
        {
            _menuAppService = menuAppService;
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                Menu menu = await _menuAppService.GetMenu();
                MenuResponse response = menu.ToResponseMenu();

                return Ok(ApiResponse<MenuResponse>.Ok("Menu retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<MenuResponse>.Error("An error occurred while retrieving menus."));
            }
        }

        [HttpGet("sandwiches")]
        public async Task<IActionResult> GetSandwiches()
        {
            try
            {
                IEnumerable<ProductResponse> response = await GetProductsByCategory((int)CategoryProduct.Sandwich);

                return Ok(ApiResponse<IEnumerable<ProductResponse>>.Ok("Sandwiches retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<IEnumerable<ProductResponse>>.Error("An error occurred while retrieving sandwiches."));
            }
        }

        [HttpGet("fries")]
        public async Task<IActionResult> GetExtras()
        {
            try
            {
                IEnumerable<ProductResponse> response = await GetProductsByCategory((int)CategoryProduct.Fries);

                return Ok(ApiResponse<IEnumerable<ProductResponse>>.Ok("Fries retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<IEnumerable<ProductResponse>>.Error("An error occurred while retrieving extras."));
            }
        }

        [HttpGet("sodas")]
        public async Task<IActionResult> GetSodas()
        {
            try
            {
                IEnumerable<ProductResponse> response = await GetProductsByCategory((int)CategoryProduct.Soda);

                return Ok(ApiResponse<IEnumerable<ProductResponse>>.Ok("Sodas retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<IEnumerable<ProductResponse>>.Error("An error occurred while retrieving sodas."));
            }
        }

        private async Task<IEnumerable<ProductResponse>> GetProductsByCategory(int category)
        {
            IEnumerable<Product> products = await _productAppService.GetProductsByCategory(category);
            return products.ToResponseProductList();
        }
    }
}