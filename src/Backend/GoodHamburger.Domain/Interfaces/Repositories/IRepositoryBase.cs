namespace GoodHamburger.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
    }
}
