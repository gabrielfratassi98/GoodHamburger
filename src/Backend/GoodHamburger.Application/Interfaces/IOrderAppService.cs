using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Application.Interfaces
{
    public interface IOrderAppService : IAppServiceBase<Order>
    {
        Result<Order> Create(List<int> idsProducts);
        Result<Order> AddProducts(long id, List<int> idsProducts);
        Result<Order> DeleteProduct(long id, int idProduct);
        Result DeleteOrder(long id);    
    }
}
