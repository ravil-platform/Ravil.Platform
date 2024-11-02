namespace Common.Exceptions
{
    public class NotFoundException(string message) : AppException(message)
    {
        public NotFoundException() : this(Resources.Messages.Validations.NotFoundException)
        {

        }
    }
}
