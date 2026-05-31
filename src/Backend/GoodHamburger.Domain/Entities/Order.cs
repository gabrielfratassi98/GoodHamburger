using GoodHamburger.Domain.Shared;

namespace GoodHamburger.Domain.Entities
{
    public class Order
    {
        private Order() { }

        public Order(Product product, bool active)
        {
            _products.Add(new OrderProduct(product.Id, product.Name, product.Category, product.Price, 1));
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            Active = active;
        }

        public long Id { get; set; }


        private readonly List<OrderProduct> _products = new();
        public IReadOnlyCollection<OrderProduct> Products => _products.AsReadOnly();

        public decimal Amount { get; private set; }
        public int DiscountPercentage { get; private set; }
        public decimal Discount { get; private set; }
        public decimal FinalAmount { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }
        public DateTime DateInactived { get; private set; }
        public bool Active { get; set; }

        public Result AddProduct(Product product)
        {
            if (product == null)
            {
                return Result.Failure("Product not found.");
            }

            if (CheckIfCategoryExists(product))
            {
                return Result.Failure($"Cannot add more than one {((CategoryProduct)product.Category).ToString().ToLower()}.");
            }

            var ordemProduct = new OrderProduct(product.Id, product.Name, product.Category, product.Price, 1);
            _products.Add(ordemProduct);

            return Result.Success();
        }

        public Result RemoveProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.IdProduct == id);
            if (product == null)
            {
                return Result.Failure("Product not found.");
            }

            _products.Remove(product);
            return Result.Success();
        }

        public void CalculateOrderAmount(decimal discount)
        {
            CalculateAmount();
            Discount = discount;
            CalculateFinalAmount();
        }

        public void UpdateDateOrder()
        {
            DateUpdated = DateTime.Now;
        }

        public void UpdateDateInactivedOrder()
        {
            DateInactived = DateTime.Now;
        }

        public void ApplyDiscountPercentage(int percentage)
        {
            DiscountPercentage = percentage;
        }

        private void CalculateAmount()
        {
            Amount = _products.Sum(c => c.TotalPrice);
        }

        private void CalculateFinalAmount()
        {
            FinalAmount = Amount - Discount;
        }

        private bool CheckIfCategoryExists(Product product)
        {
            return _products.Any(c => c.Category == product.Category);
        }

    }
}
