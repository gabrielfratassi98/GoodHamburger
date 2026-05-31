using GoodHamburger.API.Mapper;
using GoodHamburger.API.Models.Response;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuAppService _menuAppService;

        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Menu> menus = new List<Menu> { _menuAppService.GetMenu() };

                List<MenuResponse> response = menus.ToResponseMenuList();

                return Ok(ApiResponse.Ok("Menus retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving menus."));
            }
        }
    }
}
