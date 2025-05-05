namespace Shared.OrderModels
{
    public record OrderResult
    {
        public Guid Id { get; init; }
        public string UserEmail { get; init; }

        public AddressDto ShippingAdress { get; init; }

        public ICollection<OrderItemDto> OrderItems { get; init; } = new List<OrderItemDto>();
        public string PaymentStatus { get; init; } 
        public string DeliveryMethod { get; init; }
        public int? DeliveryMethodId { get; init; }
        public decimal Subtotal { get; init; }  // OrderItem.Price * OrderItem.Quantity // Total = SubTotal + Shipping Price 
        public DateTimeOffset OrderDate { get; init; } = DateTimeOffset.Now;
        public string PaymentIntentId { get; init; } = string.Empty;
        public decimal Total { get; init; }
    }
}
