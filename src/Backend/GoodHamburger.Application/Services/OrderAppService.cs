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

        public async Task<Result<Order>> Create(List<int> idsProducts)
        {
            if (idsProducts == null || !idsProducts.Any())
            {
                return Result<Order>.Failure("The product list cannot be empty.");
            }

            var productsResult = await GetValidProductsFromDb(idsProducts);
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

            await Add(order);

            return Result<Order>.Success(order);
        }

        public async Task<Result<Order>> AddProducts(long id, List<int> idsProducts)
        {
            if (idsProducts == null || !idsProducts.Any())
            {
                return Result<Order>.Failure("The product list cannot be empty.");
            }

            var productsResult = await GetValidProductsFromDb(idsProducts);
            if (productsResult.IsFailure)
            {
                return Result<Order>.Failure(productsResult.Message);
            }

            var order = await GetById(id);
            if (order is null)
            {
                return Result<Order>.Failure("Order not found.");
            }

            Result result = order.AddProducts(productsResult.Value);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

            await Update(order);

            return Result<Order>.Success(order);
        }

        public async Task<Result<Order>> DeleteProduct(long id, int idProduct)
        {
            var order = await GetById(id);
            if (order is null)
            {
                return Result<Order>.Failure("Order not found.");
            }

            Result result = order.DeleteProduct(idProduct);
            if (result.IsFailure)
            {
                return Result<Order>.Failure(result.Message);
            }

            await Update(order);

            return Result<Order>.Success(order);
        }

        public async Task<Result<Order>> FinishOrder(long id)
        {
            var order = await GetById(id);
            if (order is null)
            {
                return Result<Order>.Failure("Order not found.");
            }

            order.InactivateOrder();
            await Update(order);

            return Result<Order>.Success(order);
        }

        public async Task<Result> DeleteOrder(long id)
        {
            var order = await GetById(id);
            if (order is null)
            {
                return Result<Order>.Failure("Order not found.");
            }

            await Delete(order);

            return Result.Success("Order deleted successfully.");
        }

        private async Task<Result<List<Product>>> GetValidProductsFromDb(List<int> idsProducts)
        {
            var products = new List<Product>();

            foreach (var id in idsProducts)
            {
                Product product = await _productRepository.GetById(id); 
                if (product is null)
                {
                    return Result<List<Product>>.Failure("One or more products not found.");
                }

                products.Add(product);
            }

            return Result<List<Product>>.Success(products);
        }
    }
}
