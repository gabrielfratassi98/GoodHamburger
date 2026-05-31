using System.ComponentModel.DataAnnotations;

namespace GoodHamburger.API.Models.Request
{
    public class OrderRequest
    {
        [Required]
        public List<int> IdsProducts { get; set; }
    }
}
