using GoodHamburger.API.Models.Response;
using GoodHamburger.Domain.Entities;

namespace GoodHamburger.API.Mapper
{
    public static class ProductMap
    {
        public static ProductResponse ToResponseProduct(this Product product)
        {
            if (product is not Product)
            {
                return new ProductResponse();
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Category = product.Category,
                CategoryName = ((CategoryProduct)product.Category).ToString()
            };
        }

        public static List<ProductResponse> ToResponseProductList(this IEnumerable<Product> products)
        {
            if (!products.Any())
            {
                return new List<ProductResponse>();
            }

            return products.Select(p => p.ToResponseProduct()).ToList();
        }
    }
}
