using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetByIds(List<int> ids);
    }
}
