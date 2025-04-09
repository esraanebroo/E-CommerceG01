using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IProductService
    {
        //Get all product
        public Task<IEnumerable<ProductResultDto>> GetAllProductAsync(string? sort, int? brandId, int? typeId);
        //Get All Types
        public Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
        //Get all Brands
        public Task<IEnumerable<BrandResultDto>> GetAllBrandAsync();

        //Get ProductById
        public Task<ProductResultDto?> GetProductByIdAsync(int id);



    }
}
