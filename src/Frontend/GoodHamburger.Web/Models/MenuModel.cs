namespace GoodHamburger.Web.Models
{
    public class MenuData
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Product>? Sandwiches { get; set; }
        public IEnumerable<Product>? Extras { get; set; }
    }
}
