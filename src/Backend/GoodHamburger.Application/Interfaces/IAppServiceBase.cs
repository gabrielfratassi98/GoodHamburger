namespace GoodHamburger.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}
