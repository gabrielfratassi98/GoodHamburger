using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Application.Interfaces
{
    public interface IOrderAppService : IAppServiceBase<Order>
    {
        Result<Order> Create(List<int> idsProducts);
        Result<Order> AddProducts(long id, List<int> idsProducts);
        Result<Order> RemoveProduct(long id, int idProduct);
        Result RemoveOrder(long id);    
    }
}
