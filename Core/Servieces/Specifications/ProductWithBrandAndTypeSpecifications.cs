using Domain.Contracts;
using Domain.Entites;

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
        public ProductWithBrandAndTypeSpecifications(string? sort,int ?brandId,int?typeId) 
            : base(product=>
            (!brandId.HasValue|| product.BrandId==brandId.Value)&&
            (!typeId.HasValue||product.TypeId==typeId.Value)
            )
        {
            AddInclude(product=>product.productBrand);
            AddInclude(product=>product.ProductType);
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort.ToLower().Trim())
                {
                    case "pricedes":
                        SetOrderByDescending(p => p.Price);
                        break;
                    case "Priceasc":
                        SetOrderBy(p => p.Price);
                        break;
                    case "namedec":
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
