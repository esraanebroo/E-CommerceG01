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
        public ServiceManger(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));    
        }
        public IProductService ProductService =>_productService.Value;  
    }
}
