namespace GoodHamburger.API.Models.Response
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public IReadOnlyCollection<OrderProductResponse>? Products { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal FinalAmount { get; set; }
        public bool Active { get; set; }
    }

    public class OrderProductResponse
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
