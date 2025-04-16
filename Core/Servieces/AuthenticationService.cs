using Domain.Entites;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Services.Abstraction;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servieces
{
    public class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
    {
        public async Task<UserResultDto> Login(LoginDto loginDto)
        {//Email is already Added to an account
           var user= await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) throw new UnauthorizedException();
            //password is correct or not 
            var result= await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new UnauthorizedException();
            return new UserResultDto(user.DisplayName, "Token", user.Email);

        }

        public async Task<UserResultDto> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
               
            };
             var result= await  _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            { var error = result.Errors.Select(e => e.Description).ToList(); 
               throw new ValidtionException(error);
            }
                return new UserResultDto(user.DisplayName,"Token",user.Email);
           
        
        }
    }
}
