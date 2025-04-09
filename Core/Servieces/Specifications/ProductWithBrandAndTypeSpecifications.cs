using Domain.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ProductWithBrandAndTypeSpecifications() : base(null)
        {
            AddInclude(product=>product.productBrand);
            AddInclude(product=>product.ProductType);
        }
        
    }
}
