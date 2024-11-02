namespace Common.Exceptions
{
    public class BadRequestException(string message) : AppException(message)
    {
        public BadRequestException() : this(Resources.Messages.Validations.BadRequestException)
        {

        }
    }

 }
