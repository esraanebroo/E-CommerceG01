using Domain.Contracts;
using Domain.Entites;
using Shared;

namespace Servieces.Specifications
{
    public class ProductCountSpecification : Specifications<Product>
    {
        
        //use to retrive all products [includ[brands, types]]
        public ProductCountSpecification(ProductParametersSpecifications specifications)
            : base(product =>
            (!specifications.BrandId.HasValue || product.BrandId == specifications.BrandId.Value) &&
            (!specifications.TypeId.HasValue || product.TypeId == specifications.TypeId.Value)&&
            (string.IsNullOrWhiteSpace(specifications.Search) || product.Name.ToLower().Contains(specifications.Search.ToLower().Trim()))

            )
        {
          
        } 

    }
}
