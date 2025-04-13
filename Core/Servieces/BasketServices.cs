using AutoMapper;
using Domain.Contracts;
using Domain.Entites;
using Domain.Exceptions;
using Services.Abstraction;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servieces
{
    public class BasketServices (IBasketRepository _basketRepository , IMapper _mapper): IBasketServices
    {
        public async Task<bool> DeleteBasketAsync(string id)
        => await _basketRepository.DeleteBasketAsync(id);

        public async Task<BasketDto?> GetBasketAsync(string id)
        {
            var basket= await _basketRepository.GetBasketAsync(id);
            return basket is null?throw new BasketNotFoundExceptions(id) :_mapper.Map<BasketDto?>(basket);
        }

        public async Task<BasketDto?> UpdateBasketAsync(BasketDto? basket)
        {
            var customerBasket = await _basketRepository.UpdateBasket(_mapper.Map<CustomerBasket>(basket));
            return customerBasket is null ? throw new Exception("Can not update the basket now !!"):_mapper.Map<BasketDto>(customerBasket);
        }
    }
}
