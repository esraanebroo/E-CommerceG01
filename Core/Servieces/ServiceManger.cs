using AutoMapper;
using Domain.Contracts;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servieces
{
    public class ServiceManger : IServiceManger
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketServices> _basketServices;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManger(IUnitOfWork unitOfWork ,IMapper mapper ,IBasketRepository basketRepository , UserManager<User> userManager)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
            _basketServices = new Lazy<IBasketServices>(() => new BasketServices(basketRepository,mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager));
        }
        public IProductService ProductService =>_productService.Value;

        public IBasketServices BasketServices => _basketServices.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
