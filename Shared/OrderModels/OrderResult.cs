using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.OrderModels
{
    public record OrderResult
    {
        public Guid Id { get; init; }
        public string UserEmail { get; init; }

        public ShippingAdressDto ShippingAdress { get; init; }

        public ICollection<OrderItemDto> OrderItems { get; init; } = new List<OrderItemDto>();
        public string PaymentStatus { get; init; } 
        public string DeliveryMethod { get; init; }
        public int? DeliveryMethodId { get; init; }
        public decimal SubTotal { get; init; }  // OrderItem.Price * OrderItem.Quantity // Total = SubTotal + Shipping Price 
        public DateTimeOffset OrderDate { get; init; } = DateTimeOffset.Now;
        public string PaymentIntentId { get; init; } = string.Empty;
    }
}
