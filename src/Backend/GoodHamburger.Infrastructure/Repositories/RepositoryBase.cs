using GoodHamburger.Domain.Interfaces.Repositories;

namespace GoodHamburger.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual async Task Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
