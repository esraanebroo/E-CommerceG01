namespace Domain.Entites.OrderEntites
{
    public class Order : BaseEntity<Guid>
    {
        public string UserEmail { get; set; }

        public ShippingAdress ShippingAdress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderPaymentStatus PaymentStatus { get; set; }=OrderPaymentStatus.pending;
        public DeliveryMethod DeliveryMethod { get; set; }
        public int?  DeliveryMethodId { get; set;}
        public decimal SubTotal { get; set; }  // OrderItem.Price * OrderItem.Quantity // Total = SubTotal + Shipping Price 
        public DateTimeOffset OrderDate { get; set; }= DateTimeOffset.Now;
        public string PaymentIntentId { get; set; } = string.Empty;


    }
}
