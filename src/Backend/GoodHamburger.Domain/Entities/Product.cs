namespace GoodHamburger.Domain.Entities
{
    public class Product : Entity
    {
        private Product() { }

        public Product(string name, decimal price, CategoryProduct category)
        {
            Name = name;
            Price = price;
            Category = (int)category;
            SetSide();
        }

        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = decimal.Zero;
        public int Category { get; private set; }
        public bool Extra { get; private set; }

        private void SetSide()
        {
            Extra = Category == (int)CategoryProduct.Fries || Category == (int)CategoryProduct.Soda;
        }
    }

    public enum CategoryProduct
    {
        Sandwich = 1,
        Fries = 2,
        Soda = 3
    }
}
