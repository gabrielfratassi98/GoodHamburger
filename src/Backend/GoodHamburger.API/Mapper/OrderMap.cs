using GoodHamburger.API.Models.Response;
using GoodHamburger.Domain.Entities;

namespace GoodHamburger.API.Mapper
{
    public static class OrderMap
    {
        public static OrderResponse ToResponseOrder(this Order order)
        {
            if (order is not Order)
            {
                return new OrderResponse();
            }

            return new OrderResponse
            {
                Id = order.Id,
                Amount = order.Amount,
                Discount = order.Discount,
                FinalAmount = order.FinalAmount,
                DateCreated = order.DateCreated,
                DateUpdated = order.DateUpdated,
                DateInactived = order.DateInactived,
                Active = order.Active,
                Products = order.Products?.Select(i => i.ToResponseOrderProduct()).ToList()
            };
        }

        public static OrderProductResponse ToResponseOrderProduct(this OrderProduct item)
        {
            if (item == null) return new OrderProductResponse();

            return new OrderProductResponse
            {
                IdProduct = item.IdProduct,
                Name = item.ProductName,
                Category = item.Category,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity,
                TotalPrice = item.TotalPrice
            };
        }

        public static List<OrderResponse> ToResponseOrderList(this IEnumerable<Order> orders)
        {
            if (!orders.Any())
            {
                return new List<OrderResponse>();
            }

            return orders.Select(o => o.ToResponseOrder()).ToList();
        }
    }
}
