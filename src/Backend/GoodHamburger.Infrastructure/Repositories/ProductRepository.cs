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

        public override async Task<Product> GetById(long id)
        {
            return await _dbContext.Product.FindAsync((int)id);
        }

        public override async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.FromResult(_dbContext.Product.ToList());
        }

        public async Task<IEnumerable<Product>> GetByIds(List<int> ids)
        {
            return await Task.FromResult(_dbContext.Product.Where(p => ids.Contains(p.Id)).ToList());
        }     

        public async Task<IEnumerable<Product>> GetProductsByCategory(int category)
        {
            return await Task.FromResult(_dbContext.Product.Where(p => p.Category == category).ToList());
        }
    }
}
