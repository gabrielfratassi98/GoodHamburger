namespace GoodHamburger.Web.Models
{
    public class Order
    {
        public long Id { get; set; }
        public IReadOnlyCollection<OrderProduct>? Products { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal FinalAmount { get; set; }
        public bool Active { get; set; }
    }
}
