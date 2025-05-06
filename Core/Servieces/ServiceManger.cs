using AutoMapper;
using Domain.Contracts;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services.Abstraction;
using Shared;

namespace Servieces
{
    public class ServiceManger : IServiceManger
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketServices> _basketServices;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IOrderService> _orderService;

        public ServiceManger(IUnitOfWork unitOfWork ,IMapper mapper ,IBasketRepository basketRepository , UserManager<User> userManager, IOptions<JwtOptions> options)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
            _basketServices = new Lazy<IBasketServices>(() => new BasketServices(basketRepository,mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager,mapper, options));
            _orderService = new Lazy<IOrderService>(() => new OrderServiece(mapper, basketRepository, unitOfWork));
        }
        public IProductService ProductService =>_productService.Value;

        public IBasketServices BasketServices => _basketServices.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IOrderService OrderService =>_orderService.Value;
    }
}
