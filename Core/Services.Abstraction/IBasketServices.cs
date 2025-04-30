using Shared.Dtos;

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
