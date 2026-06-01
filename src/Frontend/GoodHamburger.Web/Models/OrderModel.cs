using System.Text.Json;

namespace GoodHamburger.Web.Models
{
    public class OrderModel : ApiResponse<OrderModel>
    {
        public long Id { get; set; }
        public List<OrderProduct>? Products { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal FinalAmount { get; set; }
        public bool Active { get; set; }
    }
}
