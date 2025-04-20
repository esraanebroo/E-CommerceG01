using AutoMapper;
using Domain.Entites.OrderEntites;
using Shared.OrderModels;

namespace Servieces.MappingProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAdress, ShippingAdressDto>();
            CreateMap<DeliveryMethod, DeliveryMethodResult>();
            CreateMap<OrderItem, OrderItemDto>().
                ForMember(d => d.ProductName, option => option.MapFrom(s => s.Product.ProductName))
               .ForMember(d => d.ProductId, option => option.MapFrom(s => s.Product.ProductId))
               .ForMember(d => d.PictureUrl, option => option.MapFrom(s => s.Product.PictureUrl));
            CreateMap<Order, OrderResult>()
                .ForMember(d => d.PaymentStatus, option => option.MapFrom(s => s.ToString()))
                .ForMember(d=>d.DeliveryMethod,option=>option.MapFrom(s=>s.DeliveryMethod.ShortName))
                .ForMember(d=>d.Total,options=>options.MapFrom(s=>s.SubTotal+s.DeliveryMethod.Price));




        }


    }
}
