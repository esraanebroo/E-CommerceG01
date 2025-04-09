using AutoMapper;
using Domain.Entites;
using Microsoft.Extensions.Configuration;
using Shared;

namespace Servieces.MappingProfiles
{
    public class PictureUrlResolver(IConfiguration configration) : IValueResolver<Product, ProductResultDto, string>
    {
        public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl)) 
                return string.Empty;
            return $"{configration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
