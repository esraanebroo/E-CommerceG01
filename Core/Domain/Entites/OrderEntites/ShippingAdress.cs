namespace Domain.Entites.OrderEntites
{
    public class ShippingAdress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

    }
}
