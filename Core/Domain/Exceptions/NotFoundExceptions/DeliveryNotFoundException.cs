namespace Domain.Exceptions.NotFoundExceptions
{
    public sealed class DeliveryNotFoundException(int id) : NotFoundExceptions($"Delivery Method with id {id} Not Found")
    {
    }
}
