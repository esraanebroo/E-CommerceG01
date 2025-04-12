using Domain.Contracts;
using Services.Abstraction;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servieces
{
    public class BasketServices (IBasketRepository _basketRepository): IBasketServices
    {
        public async Task<bool> DeleteBasketAsync(string id)
        => await _basketRepository.DeleteBasketAsync(id);

        public Task<BasketDto?> GetBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BasketDto?> UpdateBasketAsync(BasketDto? basket)
        {
            throw new NotImplementedException();
        }
    }
}
