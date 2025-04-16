namespace Domain.Exceptions
{
    public sealed class UnauthorizedException(string Msg= "Invaild Email or Password ") :Exception(Msg)
    {
    }
}
