using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Services;

namespace GoodHamburger.Domain.Services
{
    public class OrderService : IOrderService
    {
        public (int, decimal) CalculateDiscount(IReadOnlyCollection<OrderProduct> items)
        {
            decimal totalPrice = items.Sum(c => c.TotalPrice);

            bool hasSandwich = items.Any(c => c.Category == (int)CategoryProduct.Sandwich);
            bool hasFries = items.Any(c => c.Category == (int)CategoryProduct.Fries);
            bool hasSoda = items.Any(c => c.Category == (int)CategoryProduct.Soda);

            if (hasSandwich && hasFries && hasSoda)
                return (20, totalPrice * 0.20m);

            if (hasSandwich && hasSoda)
                return (15, totalPrice * 0.15m);

            if (hasSandwich && hasFries)
                return (10, totalPrice * 0.10m);

            return (0, 0m);
        }
    }
}
