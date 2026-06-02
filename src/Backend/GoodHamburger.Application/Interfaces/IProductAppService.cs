using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<Product>> GetProductsByCategory(int categoriaId);
    }
}
