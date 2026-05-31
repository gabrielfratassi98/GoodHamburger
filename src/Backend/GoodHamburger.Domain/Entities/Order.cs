using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Domain.Entities
{
    public class Order
    {
        private Order() { }

        public Order(bool active)
        {
            Active = active;
        }

        public long Id { get; set; }

        private readonly List<OrderProduct> _products = new();
        public IReadOnlyCollection<OrderProduct> Products => _products.AsReadOnly();

        public decimal Amount { get; private set; }
        public int DiscountPercentage { get; private set; }
        public decimal Discount { get; private set; }
        public decimal FinalAmount { get; private set; }
        public bool Active { get; set; }

        public Result AddProducts(List<Product> products)
        {
            if (products == null || !products.Any())
            {
                return Result.Failure("Product list cannot be empty.");
            }

            if (!Active)
            {
                return Result.Failure("Cannot modify a deleted order.");
            }

            foreach (var product in products)
            {
                if (CheckIfCategoryExists(product))
                {
                    return Result.Failure($"Cannot add more than one {((CategoryProduct)product.Category).ToString().ToLower()}.");
                }

                var ordemProduct = new OrderProduct(product.Id, product.Name, product.Category, product.Price, 1);
                _products.Add(ordemProduct);
            }

            CalculateOrderAmount();

            return Result.Success();
        }

        public Result RemoveProduct(int id)
        {
            if (!Active)
            {
                return Result.Failure("Cannot modify a deleted order.");
            }

            var productItem = _products.FirstOrDefault(p => p.IdProduct == id);
            if (productItem == null)
            {
                return Result.Failure("Product not found.");
            }

            _products.Remove(productItem);

            CalculateOrderAmount();

            return Result.Success();
        }

        public Result RemoveOrder()
        {
            Active = false;
            return Result.Success("Order removed successfully.");
        }

        public void CalculateOrderAmount()
        {
            CalculateAmount();
            ApplyDiscountRules();
            CalculateFinalAmount();
        }

        private void CalculateAmount()
        {
            Amount = Math.Round(_products.Sum(c => c.TotalPrice), 2);
        }

        private void ApplyDiscountRules()
        {
            bool hasSandwich = _products.Any(c => c.Category == (int)CategoryProduct.Sandwich);
            bool hasFries = _products.Any(c => c.Category == (int)CategoryProduct.Fries);
            bool hasSoda = _products.Any(c => c.Category == (int)CategoryProduct.Soda);

            if (hasSandwich && hasFries && hasSoda)
            {
                DiscountPercentage = 20;
                Discount = Math.Round(Amount * 0.20m, 2);
                return;
            }

            if (hasSandwich && hasSoda)
            {
                DiscountPercentage = 15;
                Discount = Math.Round(Amount * 0.15m, 2);
                return;
            }

            if (hasSandwich && hasFries)
            {
                DiscountPercentage = 10;
                Discount = Math.Round(Amount * 0.10m, 2);
                return;
            }

            DiscountPercentage = 0;
            Discount = 0m;
        }

        private void CalculateFinalAmount()
        {
            FinalAmount = Math.Round(Amount - Discount, 2);
        }

        private bool CheckIfCategoryExists(Product product)
        {
            return _products.Any(c => c.Category == product.Category);
        }
    }
}
