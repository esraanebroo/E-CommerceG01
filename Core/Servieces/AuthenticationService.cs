using Domain.Entites;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Services.Abstraction;
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
    public class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5e695578a80d8cbd7302c59ee9c2317c215c779120e362eb638592f739c2399c7c7eaf9d4bc9415707f97c739e734657141f59fadd41e45cb23f9f6865b6e5d22123f442f106d2a12c54cfe22ff2207e21e2e30df02e9730f3ade79eaa66f3322169512239460489c2c0247b42c48710c4b211b5e8c5a08c3080b6590d0867a826799ffbde1390e1f430ae651ad454ba80297a5518bf0ad65a44188c8d9a80b7506424049defdbcab0e51690c498bafda87aaebf75e6926c3e1f10afc87ba2d77a33a90364750566df827b987a799ede146a4935ebb1767f2cf150a713165ec3afe54b062b353ed2cc85449a2b2a1372823556dc4f8a4bcf970ba0ffa57cdd93"));
        
            var siginCreds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: "https://localhost:7227/", audience: "Aduance", claims: claims, DateTime.UtcNow.AddDays(30), signingCredentials: siginCreds);
            return  new JwtSecurityTokenHandler().WriteToken(token);
        
        }


    }
}
