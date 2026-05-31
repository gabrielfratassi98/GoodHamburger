using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Infrastructure.Memory;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Add(Order entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public override void Update(Order entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public override Order GetById(long id)
        {
            return _dbContext.Order
                .Include(o => o.Products)
                .FirstOrDefault(o => o.Id == id);
        }

        public override IEnumerable<Order> GetAll()
        {
            return _dbContext.Order
                .Include(o => o.Products)
                .ToList();
        }
    }
}
