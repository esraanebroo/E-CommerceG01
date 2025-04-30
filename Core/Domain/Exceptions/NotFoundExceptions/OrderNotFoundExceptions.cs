namespace Domain.Exceptions.NotFoundExceptions
{
    public sealed class OrderNotFoundExceptions(Guid id) : NotFoundExceptions($"Order With id :{id} Not found")
    {

    }
    

}
