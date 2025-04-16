using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;
using Shared.ErrorModels;
using System.Net;

namespace Presentation
{
   
    public class ProductController(IServiceManger serviceManger):ApiController
    {//Get All Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProduct([FromQuery]ProductParametersSpecifications specifications ) 
        {
            var products =await serviceManger.ProductService.GetAllProductAsync(specifications);
            return Ok(products);    
        }
        //Get All Brand
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
        {
            var Brands = await serviceManger.ProductService.GetAllBrandAsync();
            return Ok(Brands);
        }
        //Get All Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
        {
            var types = await serviceManger.ProductService.GetAllTypesAsync();
            return Ok(types);
        }
      
        [ProducesResponseType(typeof(ProductResultDto), (int)HttpStatusCode.OK)]

        //Get product by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
        {
            var product = await serviceManger.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }

}
