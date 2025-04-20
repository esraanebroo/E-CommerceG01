namespace Domain.Entites.OrderEntites
{
    public class ShippingAdress
    {
        public ShippingAdress()
        {
            
        }
        public ShippingAdress(string firstName, string lastName, string country, string city, string street) 
        { 
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            City = city;
            Street = street;
           
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        

    }
}
