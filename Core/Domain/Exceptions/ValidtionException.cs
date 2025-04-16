namespace Domain.Exceptions
{
    public class ValidtionException:Exception
    {
        public IEnumerable<string> Errors { get; set; }
        public ValidtionException(IEnumerable<string> error):base("Validation filed") 
        {
            Errors = error;
        }
    }
}
