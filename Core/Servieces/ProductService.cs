using AutoMapper;
using Domain.Contracts;
using Domain.Entites;
using Services.Abstraction;
using Servieces.Specifications;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servieces
{
    internal class ProductService(IUnitOfWork UnitOfWork,IMapper Mapper) : IProductService
    {

        public async Task<IEnumerable<BrandResultDto>> GetAllBrandAsync()
        {
            var brands=await UnitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            var Result=Mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return Result;
        }

        public async Task<IEnumerable<ProductResultDto>> GetAllProductAsync(string? sort, int? brandId, int? typeId)
        {
            var Product = await UnitOfWork.GetRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications(sort,brandId,typeId));
            var Result = Mapper.Map<IEnumerable<ProductResultDto>>(Product);
            return Result;
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var Type = await UnitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var Result = Mapper.Map<IEnumerable<TypeResultDto>>(Type);
            return Result;
        }

        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var Product=await UnitOfWork.GetRepository<Product,int>().GetByIdAsync(new ProductWithBrandAndTypeSpecifications(id));
            var Result = Mapper.Map<ProductResultDto>(Product);
            return Result;

 
        }
    }

}
