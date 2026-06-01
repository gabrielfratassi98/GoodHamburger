namespace GoodHamburger.Web.Models
{
    public class MenuData
    {
        public string Name { get; set; } = string.Empty;
        public List<Product>? Sandwiches { get; set; }
        public List<Product>? Extras { get; set; }
    }
}
