namespace Domain.Exceptions.NotFoundExceptions
{
    public sealed class BasketNotFoundExceptions : NotFoundExceptions
    {
        public BasketNotFoundExceptions(string id) : base($"The Basket with id {id} is not found") { }


    }
}
