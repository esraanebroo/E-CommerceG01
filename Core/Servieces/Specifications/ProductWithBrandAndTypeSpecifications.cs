using Domain.Contracts;
using Domain.Entites;
using Shared;

namespace Servieces.Specifications
{
    public class ProductWithBrandAndTypeSpecifications:Specifications<Product>
    {   //use to retrive product by id [where[id] , include [brand - type]]
        public ProductWithBrandAndTypeSpecifications(int id):base(Product=>Product.Id ==id)
        {
            AddInclude(product => product.productBrand);
            AddInclude(product => product.ProductType);
        }
        //use to retrive all products [includ[brands, types]]
        public ProductWithBrandAndTypeSpecifications(ProductParametersSpecifications specifications) 
            : base(product=>
            (!specifications.BrandId.HasValue|| product.BrandId== specifications.BrandId.Value)&&
            (!specifications.TypeId.HasValue||product.TypeId== specifications.TypeId.Value)&&
            (string.IsNullOrWhiteSpace(specifications.Search)||product.Name.ToLower().Contains(specifications.Search.ToLower().Trim()))
            )
        {
            AddInclude(product=>product.productBrand);
            AddInclude(product=>product.ProductType);
            ApplyPagination(specifications.PageIndex, specifications.PageSize);
            if (specifications.Sort is not null)
            {
                switch (specifications.Sort)
                {
                    case ProductSortOptions.PriceDesc:
                        SetOrderByDescending(p => p.Price);
                        break;
                    case ProductSortOptions.PriceAsc:
                        SetOrderBy(p => p.Price);
                        break;
                    case ProductSortOptions.NameDesc:
                        SetOrderByDescending(p => p.Name);
                        break;
                    default:
                        SetOrderBy(p => p.Name);
                        break;
                }
            }
        }
        
    }
}
