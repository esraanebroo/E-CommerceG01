using AutoMapper;
using Domain.Contracts;
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
        public ServiceManger(IUnitOfWork unitOfWork ,IMapper mapper ,IBasketRepository basketRepository)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
            _basketServices = new Lazy<IBasketServices>(() => new BasketServices(basketRepository,mapper));
        }
        public IProductService ProductService =>_productService.Value;

        public IBasketServices BasketServices => _basketServices.Value;
    }
}
