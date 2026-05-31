using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Infrastructure.Memory;

namespace GoodHamburger.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override Product GetById(long id)
        {
            return _dbContext.Product.Find((int)id);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _dbContext.Product.ToList();
        }

        public IEnumerable<Product> GetByIds(List<int> ids)
        {
            return _dbContext.Product.Where(p => ids.Contains(p.Id)).ToList();
        }     

        public IEnumerable<Product> GetProductsByCategory(int category)
        {
            return _dbContext.Product.Where(p => p.Category == category).ToList();
        }
    }
}
