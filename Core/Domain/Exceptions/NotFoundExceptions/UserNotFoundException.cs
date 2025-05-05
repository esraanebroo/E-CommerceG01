namespace Domain.Exceptions.NotFoundExceptions
{
    public class UserNotFoundException(string email):NotFoundExceptions($"The User With email {email} not found")
    {
    }
}
