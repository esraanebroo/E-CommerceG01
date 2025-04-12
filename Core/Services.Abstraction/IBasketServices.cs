using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IBasketServices
    {
        //Get
        Task<BasketDto?> GetBasketAsync(string id);
       //Delete
        Task<bool> DeleteBasketAsync(string id);

        Task<BasketDto?> UpdateBasketAsync(BasketDto? basket);



    }
}
