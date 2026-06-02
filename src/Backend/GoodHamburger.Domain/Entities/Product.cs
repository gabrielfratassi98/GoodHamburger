namespace GoodHamburger.Domain.Entities
{
    public class Product : Entity
    {
        private Product() { }

        public Product(string name, decimal price, string description, string img, CategoryProduct category)
        {
            Name = name;
            Price = price;
            Category = (int)category;
            Description = description;
            ImageUrl = img;
            SetExtra();
        }

        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = decimal.Zero;
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int Category { get; private set; }
        public bool Extra { get; private set; }

        private void SetExtra()
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
