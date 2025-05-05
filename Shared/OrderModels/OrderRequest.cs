namespace Shared.OrderModels
{
    public record OrderRequest
    {
        public string BasketId { get; init; }
        public AddressDto ShippingAdress { get; init; }
        public int DeliveryMethodId { get; init; }
    }
}
