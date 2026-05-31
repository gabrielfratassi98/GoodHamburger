using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;

namespace GoodHamburger.Application.Services
{
    public class MenuAppService : IMenuAppService
    {
        private readonly IProductRepository _productRepository;

        public MenuAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Menu GetMenu()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            if (!products.Any())
            {
                return new Menu(new List<Product>());
            }

            return new Menu(products.ToList());
        }
    }
}
