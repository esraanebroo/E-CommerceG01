using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.Dtos;
using Shared.OrderModels;
using System.Security.Claims;

namespace Presentation
{
    public class AuthenticationController(IServiceManger serviceManger) : ApiController
    {
        // Baseurl/Api/controller name /login
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        {
            var result = await serviceManger.AuthenticationService.Login(loginDto);
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDto>> Register(RegisterDto registerDto)
        {
            var result = await serviceManger.AuthenticationService.Register(registerDto);
            return Ok(result);
        }
        [HttpGet("EmailExist")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return Ok(await serviceManger.AuthenticationService.CheckIfEmailExist(email));

        }
        [Authorize]
        [HttpGet]//Get : Baseurl/api/Authentication
        public async Task<ActionResult<UserResultDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManger.AuthenticationService.GetUserByEmail(email);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Address")]//Get : Baseurl/api/Authentication/Address
        public async Task<ActionResult<AddressDto>> GetAddress()
        {
            var email= User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManger.AuthenticationService.GetUserAddress(email);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("Address")]//Get : Baseurl/api/Authentication/Address
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto address) 
        {
            var email=User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManger.AuthenticationService.UpdateUserAddress(address,email);
            return Ok(result);
        }

    }
}
