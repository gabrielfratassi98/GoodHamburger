namespace GoodHamburger.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
