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
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Menu> menus = new List<Menu> { _menuAppService.GetMenu() };
                List<MenuResponse> response = menus.ToResponseMenuList();

                return Ok(ApiResponse.Ok("Menu retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving menus."));
            }
        }

        [HttpGet("sandwiches")]
        public ActionResult GetSandwiches()
        {
            try
            {
                IEnumerable<ProductResponse> response = GetProductsByCategory((int)CategoryProduct.Sandwich);

                return Ok(ApiResponse.Ok("Sandwiches retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving sandwiches."));
            }
        }

        [HttpGet("fries")]
        public ActionResult GetExtras()
        {
            try
            {
                IEnumerable<ProductResponse> response = GetProductsByCategory((int)CategoryProduct.Fries);

                return Ok(ApiResponse.Ok("Fries retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving extras."));
            }
        }

        [HttpGet("sodas")]
        public ActionResult GetSodas()
        {
            try
            {
                IEnumerable<ProductResponse> response = GetProductsByCategory((int)CategoryProduct.Soda);

                return Ok(ApiResponse.Ok("Sodas retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving sodas."));
            }
        }

        private IEnumerable<ProductResponse> GetProductsByCategory(int category)
        {
            IEnumerable<Product> products = _productAppService.GetProductsByCategory(category);
            return products.ToResponseProductList();
        }
    }
}