using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Domain.Interfaces.Services;
using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Application.Services
{
    public class OrderAppService : AppServiceBase<Order>, IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IProductRepository _productRepository;

        public OrderAppService
        (
            IOrderRepository orderRepository,
            IOrderService orderService,
            IProductRepository productRepository
        ) : base(orderRepository)
        {
            _orderService = orderService;
            _productRepository = productRepository;
        }

        public Result<Order> Create(int idProduct)
        {
            Product productDb = _productRepository.GetById(idProduct);
            if (productDb is not Product)
            {
                return Result<Order>.Failure("Product not found.");
            }

            var order = new Order(productDb, true);

            (int, decimal) discount = _orderService.CalculateDiscount(order.Products);

            order.ApplyDiscountPercentage(discount.Item1);
            order.CalculateOrderAmount(discount.Item2);

            Add(order);

            return Result<Order>.Success(order);
        }

        public Result<Order> AddProduct(long id, int idProduct)
        {
            Product productDb = _productRepository.GetById(idProduct);
            if (productDb is not Product)
            {
                return Result<Order>.Failure("Product not found.");
            }

            var order = GetById(id);
            if (order is not Order)
            {
                return Result<Order>    .Failure("Order not found.");
            }

            Result result = order.AddProduct(productDb);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

            (int, decimal) discount = _orderService.CalculateDiscount(order.Products);

            order.ApplyDiscountPercentage(discount.Item1);
            order.CalculateOrderAmount(discount.Item2);

            order.UpdateDateOrder();

            Update(order);

            return Result<Order>.Success(order);
        }

        public Result<Order> RemoveProduct(long id, int idProduct)
        {
            var order = GetById(id);
            if (order is not Order)
            {
                return Result<Order>.Failure("Order not found.");
            }

            Result result = order.RemoveProduct(idProduct);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

            (int, decimal) discount = _orderService.CalculateDiscount(order.Products);

            order.ApplyDiscountPercentage(discount.Item1);
            order.CalculateOrderAmount(discount.Item2);

            order.UpdateDateOrder();

            Update(order);

            return Result<Order>.Success(order);
        }

        public Result RemoveOrder(long id)
        {
            var order = GetById(id);
            if (order is not Order)
            {
                return Result.Failure("Order not found.");
            }

            order.Active = false;
            order.UpdateDateOrder();
            order.UpdateDateInactivedOrder();

            Update(order);

            return Result.Success();
        }
    }
}
