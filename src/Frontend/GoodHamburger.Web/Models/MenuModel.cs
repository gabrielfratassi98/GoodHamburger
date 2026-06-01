namespace GoodHamburger.Web.Models
{
    public class MenuApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<MenuData> Data { get; set; }
    }

    public class MenuData
    {
        public string Name { get; set; }
        public List<Product> Sandwiches { get; set; }
        public List<Product> Extras { get; set; }
    }
}
