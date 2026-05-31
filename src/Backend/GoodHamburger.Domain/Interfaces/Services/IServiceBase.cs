namespace GoodHamburger.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
