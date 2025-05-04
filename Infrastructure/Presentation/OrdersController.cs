using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.OrderModels;
using System.Security.Claims;

namespace Presentation
{
    public class OrdersController(IServiceManger serviceManger) : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<OrderResult>> Create(OrderRequest orderRequest)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var orderResult = await serviceManger.OrderService.CreateOrderAsync(orderRequest, userEmail);
            return Ok(orderResult);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResult>>> GetAllOrders()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var orderResult = await serviceManger.OrderService.GetAllOrderByEmailAsync(userEmail);
            return Ok(orderResult);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResult>> GetOrder(Guid id) 
        {
            var order = await serviceManger.OrderService.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpGet("DeliveryMethod")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodResult>>> GetDeliveryMethods()
        {
            return Ok( await serviceManger.OrderService.GetDeliveryMethodsAsync());
        }
    }
}
