namespace GoodHamburger.API.Models.Response
{
    public class MenuResponse
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductResponse>? Sandwiches { get; set; }
        public List<ProductResponse>? Extras { get; set; }
    }
}