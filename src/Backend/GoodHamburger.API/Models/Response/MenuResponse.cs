namespace GoodHamburger.API.Models.Response
{
    public class MenuResponse
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductResponse>? Sandwiches { get; set; }
        public List<ProductResponse>? Extras { get; set; }
    }

    public class MenuSandwichesResponse
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductResponse>? Sandwiches { get; set; }
    }

    public class MenuFriesResponse
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductResponse>? Fries { get; set; }
    }

    public class MenuSodasResponse
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductResponse>? Sodas { get; set; }
    }

}