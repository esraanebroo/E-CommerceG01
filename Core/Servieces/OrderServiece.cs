using AutoMapper;
using Domain.Contracts;
using Domain.Entites;
using ShippingAddress = Domain.Entites.OrderEntites.Address;
using Domain.Entites.OrderEntites;
using Domain.Exceptions;
using Services.Abstraction;
using Shared.OrderModels;
using Servieces.Specifications;
using Domain.Exceptions.NotFoundExceptions;

namespace Servieces
{
    public class OrderServiece(IMapper mapper, IBasketRepository basketRepository ,IUnitOfWork unitOfWork ) : IOrderService
    {
        public async Task<OrderResult> CreateOrderAsync(OrderRequest request, string userEmail)
        {
            var shippingAddress = mapper.Map<ShippingAddress>(request.ShippingAdress);
            var basket = await basketRepository.GetBasketAsync(request.BasketId)?? throw new BasketNotFoundExceptions(request.BasketId);
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await unitOfWork.GetRepository<Product,int>().GetByIdAsync(item.Id)?? throw new ProductNotFoundException(item.Id);
                orderItems.Add(CreateOrderItem(item,product));
            }
            var deliveryMethod = await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetByIdAsync(request.DeliveryMethodId) ?? throw new DeliveryNotFoundException(request.DeliveryMethodId);
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);
            var order = new Order(userEmail,shippingAddress,orderItems,deliveryMethod,subTotal);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<OrderResult>(order);


        }

        private OrderItem CreateOrderItem(BasketItem item, Product product)
             => new OrderItem(new ProductInOrderItem(product.Id, product.Name, product.PictureUrl), item.Quantity, product.Price);
        //Another way of writing method 
        //{
        //    var productInOrderItem = new ProductInOrderItem(product.Id, product.Name, product.PictureUrl);
        //    return new OrderItem(productInOrderItem, item.Quantity, product.Price);
        //}

        public async Task<IEnumerable<OrderResult>> GetAllOrderByEmailAsync(string userEmail)
        {
           var order = await unitOfWork.GetRepository<Order,Guid>()
                .GetAllAsync(new OrderWithIncludesSpecifications(userEmail));
            return mapper.Map<IEnumerable<OrderResult>>(order);

        }
        public async Task<OrderResult> GetOrderByIdAsync(Guid id)
        {
          var order = await unitOfWork.GetRepository<Order,Guid>()
                .GetByIdAsync(new OrderWithIncludesSpecifications(id))??throw new OrderNotFoundExceptions(id);
            return mapper.Map<OrderResult>(order);

        }

        public async Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync()
        {
          var methods = await unitOfWork.GetRepository<DeliveryMethod,int>().GetAllAsync();
            return mapper.Map<IEnumerable<DeliveryMethodResult>>(methods);
        }

       
    }
}
