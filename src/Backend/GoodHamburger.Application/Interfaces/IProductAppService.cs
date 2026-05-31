using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.Interfaces
{
    public interface IProductAppService
    {
        IEnumerable<Product> GetProductsByCategory(int categoriaId);
    }
}
