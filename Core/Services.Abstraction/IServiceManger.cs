namespace Services.Abstraction
{
    public interface IServiceManger
    {
        public IProductService ProductService { get; }
        public IBasketServices BasketServices { get; }
        public IAuthenticationService AuthenticationService { get; }
        public IOrderService OrderService { get;}

    }
}
