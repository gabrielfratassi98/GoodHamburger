namespace GoodHamburger.Domain.Entities
{
    public class Menu : Entity
    {
        public Menu(List<Product> products)
        {
            Create(products);
        }

        public string Name { get; set; } = "Principal Menu";

        private readonly List<Product> _sandwiches = new();
        public IReadOnlyCollection<Product> Sandwiches => _sandwiches.AsReadOnly();

        private readonly List<Product> _extras = new();
        public IReadOnlyCollection<Product> Extras => _extras.AsReadOnly();

        private void Create(List<Product> products)
        {
            if (!products.Any())
            {
                return;
            }

            _sandwiches.Clear();
            _extras.Clear();

            _sandwiches.AddRange(products.Where(p => p.Category == (int)CategoryProduct.Sandwich));

            _extras.AddRange(products.Where(p => p.Category == (int)CategoryProduct.Fries
                                              || p.Category == (int)CategoryProduct.Soda));
        }
    }
}
