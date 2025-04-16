using AutoMapper;
using Domain.Contracts;
using Domain.Entites;
using Domain.Exceptions;
using Services.Abstraction;
using Servieces.Specifications;
using Shared;

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

        public async Task<PaginatedResult<ProductResultDto>> GetAllProductAsync(ProductParametersSpecifications specifications)
        {
            var Product = await UnitOfWork.GetRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications(specifications));
            var totalcount = await UnitOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecification(specifications)); 
            var ProductsResult = Mapper.Map<IEnumerable<ProductResultDto>>(Product);
            //return Result;
            var result = new PaginatedResult<ProductResultDto>(
                ProductsResult.Count(),
                specifications.PageIndex,
                totalcount,
                ProductsResult
                );
            return result;
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
            //var Result = Mapper.Map<ProductResultDto>(Product);
            //return Result;
            return Product is null ? throw new  ProductNotFoundException(id): Mapper.Map<ProductResultDto>(Product);

        }
    }

}
