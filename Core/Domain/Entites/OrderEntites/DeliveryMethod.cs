namespace Domain.Entites.OrderEntites
{
    public class DeliveryMethod:BaseEntity<int>
    {
        public DeliveryMethod()
        {
            
        }
        public DeliveryMethod(string shortName, string description, decimal price, string deliveryTime)
        {
            ShortName = shortName;
            Description = description;
            Price = price;
            DeliveryTime = deliveryTime;
        }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }//Within a day 

        public string DeliveryTime { get; set; }
    }
}
