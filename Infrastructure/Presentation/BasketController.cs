using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BasketController(IServiceManger _serviceManger):ControllerBase
    {
        [HttpGet("{id}")] //get :baseUrl/api/Basket/id
        public async Task<ActionResult<BasketDto>> Get(string id)
        {
            var basket=await _serviceManger.BasketServices.GetBasketAsync(id);
            return Ok(basket);
        }
        [HttpPost] //post
        public async Task<ActionResult<BasketDto>> Update(BasketDto basketDto)
        {
            var basket = await _serviceManger.BasketServices.UpdateBasketAsync(basketDto);
            return Ok(basket);
        }
        [HttpDelete("{id}")] // delete
        public async Task<ActionResult> Delete(string id)
        {
            await _serviceManger.BasketServices.DeleteBasketAsync(id);
            return NoContent();
        }

    }
}
