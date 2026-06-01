namespace GoodHamburger.Web.Models
{
    public class OrderProduct
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
