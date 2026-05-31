using GoodHamburger.API.Mapper;
using GoodHamburger.API.Models.Request;
using GoodHamburger.API.Models.Response;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Services;
using GoodHamburger.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                Result<Order> result = _orderAppService.Create(model.IdProduct);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse.Error(result.Message));
                }

                return Created(string.Empty, ApiResponse.Ok("Order created successfully.", result.Value));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while adding the order."));
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Order> orders = _orderAppService.GetAll();

                List<OrderResponse> response = OrderMap.ToResponseOrderList(orders);

                return Ok(ApiResponse.Ok("Orders retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving the orders."));
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
                    return NotFound(ApiResponse.Error("Order not found.", new() ));
                }

                OrderResponse response = OrderMap.ToResponseOrder(order);

                return Ok(ApiResponse.Ok("Order retrieved successfully.", response));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while retrieving the order."));
            }
        }

        [HttpPost("{id:long}/product")]
        public ActionResult AddProduct(long id, [FromBody] OrderRequest model)
        {
            try
            {
                Result<Order> result = _orderAppService.AddProduct(id, model.IdProduct);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse.Error(result.Message));
                }

                return Ok(ApiResponse.Ok("Product added successfully.", result.Value));
            }
            catch
            {
                return StatusCode(500, ApiResponse.Error("An error occurred while adding the order."));
            }
        }

        [HttpDelete("{id:long}/product/{idProduct:int}")]
        public ActionResult RemoveProduct(long id, int idProduct)
        {
            try
            {
                Result<Order> result = _orderAppService.RemoveProduct(id, idProduct);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse.Error(result.Message));
                }

                return Ok(ApiResponse.Ok("Product removed successfully.", result.Value));
            }
            catch
            {
                return BadRequest(ApiResponse.Error("An error occurred while removing the product from the order."));
            }
        }

        [HttpDelete("{id:long}")]
        public ActionResult Remove(long id)
        {
            try
            {
                Result result = _orderAppService.RemoveOrder(id);
                if (result.IsFailure)
                {
                    return BadRequest(ApiResponse.Error(result.Message));
                }

                return Ok(ApiResponse.Ok("Order deleted successfully."));
            }
            catch
            {
                return BadRequest(ApiResponse.Error("An error occurred while deleting the order."));
            }
        }
    }
}