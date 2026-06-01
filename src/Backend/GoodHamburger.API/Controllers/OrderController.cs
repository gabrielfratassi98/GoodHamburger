using GoodHamburger.API.Mapper;
using GoodHamburger.API.Models.Request;
using GoodHamburger.API.Models.Response;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] OrderRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<OrderResponse>.Error("Required one or more products."));
                }

                Result<Order> result = _orderAppService.Create(model.IdsProducts);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse<OrderResponse>.Error(result.Message));
                }

                OrderResponse response = OrderMap.ToResponseOrder(result.Value);

                return Created(string.Empty, ApiResponse<OrderResponse>.Ok("Order created successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<OrderResponse>.Error("An error occurred while adding the order."));
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Order> orders = _orderAppService.GetAll();

                List<OrderResponse> response = OrderMap.ToResponseOrderList(orders);

                return Ok(ApiResponse<List<OrderResponse>>.Ok("Orders retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<List<OrderResponse>>.Error("An error occurred while retrieving the orders."));
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            try
            {
                Order order = _orderAppService.GetById(id);
                if (order is not Order)
                {
                    return NotFound(ApiResponse<OrderResponse>.Error("Order not found.", new() ));
                }

                OrderResponse response = OrderMap.ToResponseOrder(order);

                return Ok(ApiResponse<OrderResponse>.Ok("Order retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<OrderResponse>.Error("An error occurred while retrieving the order."));
            }
        }

        [HttpPost("{id:long}/products")]
        public ActionResult AddProduct(long id, [FromBody] OrderRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<OrderResponse>.Error("Required one or more products."));
                }

                Result<Order> result = _orderAppService.AddProducts(id, model.IdsProducts);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse<OrderResponse>.Error(result.Message));
                }

                OrderResponse response = OrderMap.ToResponseOrder(result.Value);

                return Ok(ApiResponse<OrderResponse>.Ok("Product added successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse<OrderResponse>.Error("An error occurred while adding the order."));
            }
        }

        [HttpDelete("{id:long}/products/{idProduct:int}")]
        public ActionResult DeleteProduct(long id, int idProduct)
        {
            try
            {
                Result<Order> result = _orderAppService.DeleteProduct(id, idProduct);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse<OrderResponse>.Error(result.Message));
                }

                OrderResponse response = OrderMap.ToResponseOrder(result.Value);

                return Ok(ApiResponse<OrderResponse>.Ok("Product deleted successfully.", response));
            }
            catch
            {
                return BadRequest(ApiResponse<OrderResponse>.Error("An error occurred while deleting the product from the order."));
            }
        }

        [HttpDelete("{id:long}")]
        public ActionResult Delete(long id)
        {
            try
            {
                Result result = _orderAppService.DeleteOrder(id);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse<OrderResponse>.Error(result.Message));
                }

                return Ok(ApiResponse<OrderResponse>.Ok("Order deleted successfully."));
            }
            catch
            {
                return BadRequest(ApiResponse<OrderResponse>.Error("An error occurred while deleting the order."));
            }
        }
    }
}
