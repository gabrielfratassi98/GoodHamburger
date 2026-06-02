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

        public override async Task Add(Order entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task Update(Order entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<Order> GetById(long id)
        {
            return await _dbContext.Order
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public override async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Order
                .Include(o => o.Products)
                .ToListAsync();
        }

        public override async Task Delete(Order entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
