namespace Shared.OrderModels
{
    public record OrderRequest
    {
        public string BasketId { get; init; }
        public ShippingAdressDto ShippingAdress { get; init; }
        public int DeliveryMethodId { get; init; }
    }
}
