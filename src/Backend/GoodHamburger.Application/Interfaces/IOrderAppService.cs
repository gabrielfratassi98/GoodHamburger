using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Application.Interfaces
{
    public interface IOrderAppService : IAppServiceBase<Order>
    {
        Result<Order> Create(int idProduct);
        Result<Order> AddProduct(long id, int idProduct);
        Result<Order> RemoveProduct(long id, int idProduct);
        Result RemoveOrder(long id);    
    }
}
