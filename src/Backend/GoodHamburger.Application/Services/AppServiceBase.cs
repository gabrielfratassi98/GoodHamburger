using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Interfaces.Repositories;

namespace GoodHamburger.Application.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public AppServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            await _repository.Delete(entity);
        }
    }
}
