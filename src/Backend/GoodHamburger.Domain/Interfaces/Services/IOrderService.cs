using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        (int, decimal) CalculateDiscount(IReadOnlyCollection<OrderProduct> items);
    }
}
