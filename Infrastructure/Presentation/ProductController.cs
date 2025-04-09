using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [Controller]
    [Route("api/[Controller]")]
    public class ProductController(IServiceManger serviceManger):ControllerBase
    {//Get All Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProduct(string? sort, int? brandId, int? typeId) 
        {
            var products =await serviceManger.ProductService.GetAllProductAsync(sort,brandId, typeId);
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

        //Get product by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
        {
            var product = await serviceManger.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }

}
