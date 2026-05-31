namespace GoodHamburger.Domain.Entities
{
    public class OrderProduct : Entity
    {
        private OrderProduct() { }

        public OrderProduct(int idProduct, string productName, int category, decimal unitPrice, int quantity)
        {
            IdProduct = idProduct;
            ProductName = productName;
            Category = category;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int IdProduct { get; private set; }
        public string ProductName { get; private set; }
        public int Category { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
