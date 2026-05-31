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

        public Result<Order> Create(List<int> idsProducts)
        {
            if (idsProducts == null || !idsProducts.Any())
            {
                return Result<Order>.Failure("The product list cannot be empty.");
            }

            var productsResult = GetValidProductsFromDb(idsProducts);
            if (productsResult.IsFailure)
            {
                return Result<Order>.Failure(productsResult.Message);
            }

            var order = new Order(true);

            Result addResult = order.AddProducts(productsResult.Value);
            if (addResult.IsFailure)
            {
                return Result<Order>.Failure(addResult.Message);
            }

            Add(order);

            return Result<Order>.Success(order);
        }

        public Result<Order> AddProducts(long id, List<int> idsProducts)
        {
            if (idsProducts == null || !idsProducts.Any())
            {
                return Result<Order>.Failure("The product list cannot be empty.");
            }

            var productsResult = GetValidProductsFromDb(idsProducts);
            if (productsResult.IsFailure)
            {
                return Result<Order>.Failure(productsResult.Message);
            }

            var order = GetById(id);
            if (order is null)
            {
                return Result<Order>.Failure("Order not found.");
            }

            Result result = order.AddProducts(productsResult.Value);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

            Update(order);

            return Result<Order>.Success(order);
        }

        public Result<Order> DeleteProduct(long id, int idProduct)
        {
            var order = GetById(id);
            if (order is null)
            {
                return Result<Order>.Failure("Order not found.");
            }

            Result result = order.DeleteProduct(idProduct);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

            Update(order);

            return Result<Order>.Success(order);
        }

        public Result DeleteOrder(long id)
        {
            var order = GetById(id);
            if (order is null)
            {
                return Result.Failure("Order not found.");
            }

            order.DeleteOrder();

            Update(order);

            return Result.Success();
        }

        private Result<List<Product>> GetValidProductsFromDb(List<int> idsProducts)
        {
            var productsDb = idsProducts.Select(id => _productRepository.GetById(id)).ToList();

            if (productsDb.Any(product => product is null))
            {
                return Result<List<Product>>.Failure("One or more products not found.");
            }

            return Result<List<Product>>.Success(productsDb);
        }
    }
}
