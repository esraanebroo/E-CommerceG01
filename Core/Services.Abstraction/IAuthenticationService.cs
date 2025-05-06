using Shared.Dtos;
using Shared.OrderModels;

namespace Services.Abstraction
{
    public interface IAuthenticationService
    {
        public Task<UserResultDto> Login(LoginDto loginDto);
        public Task<UserResultDto> Register(RegisterDto registerDto);
        //Get Current user
        public Task<UserResultDto> GetUserByEmail(string email);
        //Check If emailexist 
        public Task<bool> CheckIfEmailExist(string email);
        //Update user address
        public Task<AddressDto> UpdateUserAddress(AddressDto addressDto , string email); 
        //Get user address
        public Task<AddressDto> GetUserAddress(string email);





    }
}
