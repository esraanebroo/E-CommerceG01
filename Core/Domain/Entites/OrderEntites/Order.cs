namespace Domain.Entites.OrderEntites
{
    public class Order : BaseEntity<Guid>
    {
        public Order()
        {
            
        }
        public Order(string userEmail,
            Address shippingAdress,
            ICollection<OrderItem> orderItems, 
            DeliveryMethod deliveryMethod,
            decimal subTotal
            )

        {
            UserEmail = userEmail;
            ShippingAdress = shippingAdress;
            OrderItems = orderItems;
            DeliveryMethod = deliveryMethod;
            SubTotal = subTotal;
        }

        public string UserEmail { get; set; }

        public Address ShippingAdress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderPaymentStatus PaymentStatus { get; set; }= OrderPaymentStatus.pending;
        public DeliveryMethod DeliveryMethod { get; set; }
        public int?  DeliveryMethodId { get; set;}
        public decimal SubTotal { get; set; }  // OrderItem.Price * OrderItem.Quantity // Total = SubTotal + Shipping Price 
        public DateTimeOffset OrderDate { get; set; }= DateTimeOffset.Now;
        public string PaymentIntentId { get; set; } = string.Empty;


    }
}
