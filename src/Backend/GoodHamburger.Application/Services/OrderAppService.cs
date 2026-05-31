using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Application.Services
{
    public class OrderAppService : AppServiceBase<Order>, IOrderAppService
    {
        private readonly IProductRepository _productRepository;

        public OrderAppService
        (
            IOrderRepository orderRepository,
            IProductRepository productRepository
        ) : base(orderRepository)
        {
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
                return Result<Order>.Failure("Order not found.");
            }

            Result result = order.AddProduct(productDb);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

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

            order.RemoveOrder();

            Update(order);

            return Result.Success();
        }
    }
}
