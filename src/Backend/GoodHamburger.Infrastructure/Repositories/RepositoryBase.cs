using GoodHamburger.Domain.Interfaces.Repositories;

namespace GoodHamburger.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(long id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
