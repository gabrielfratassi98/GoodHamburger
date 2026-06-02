using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Application.Interfaces
{
    public interface IOrderAppService : IAppServiceBase<Order>
    {
        Task<Result<Order>> Create(List<int> idsProducts);
        Task<Result<Order>> AddProducts(long id, List<int> idsProducts);
        Task<Result<Order>> DeleteProduct(long id, int idProduct);
        Task<Result<Order>> FinishOrder(long id);
        Task<Result> DeleteOrder(long id);
    }
}
