using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetByIds(List<int> ids);
        Task<IEnumerable<Product>> GetProductsByCategory(int category);
    }
}
