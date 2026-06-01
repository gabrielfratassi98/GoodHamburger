using GoodHamburger.API.Models.Response;
using GoodHamburger.Domain.Entities;

namespace GoodHamburger.API.Mapper
{
    public static class MenuMap
    {
        public static MenuResponse ToResponseMenu(this Menu menu)
        {
            if (menu is not Menu)
            {
                return new MenuResponse();
            }

            return new MenuResponse
            {
                Name = menu.Name,
                Sandwiches = menu.Sandwiches?.ToResponseProductList(),
                Extras = menu.Extras?.ToResponseProductList()
            };
        }
    }
}