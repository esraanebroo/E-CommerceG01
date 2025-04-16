using Domain.Entites;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstraction;
using Shared;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Servieces
{
    public class AuthenticationService(UserManager<User> _userManager , IOptions<JwtOptions> options) : IAuthenticationService
    {
        public async Task<UserResultDto> Login(LoginDto loginDto)
        {//Email is already Added to an account
           var user= await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) throw new UnauthorizedException();
            //password is correct or not 
            var result= await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new UnauthorizedException();
            return new UserResultDto(user.DisplayName, await CreateTokenAsync(user), user.Email);

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
                return new UserResultDto(user.DisplayName,await CreateTokenAsync(user),user.Email);        
        }


        private async Task<string> CreateTokenAsync(User user)
        {
            var jwtOptions = options.Value;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.DisplayName),
                new Claim(ClaimTypes.Email,user.Email)
            };
            var roles= await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
        
            var siginCreds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: jwtOptions.Issuer, audience: jwtOptions.Issuer, claims: claims,expires: DateTime.UtcNow.AddDays(jwtOptions.ExpirationInDays), signingCredentials: siginCreds);
            return  new JwtSecurityTokenHandler().WriteToken(token);
        
        }


    }
}
