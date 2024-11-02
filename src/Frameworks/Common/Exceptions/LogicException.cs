namespace Common.Exceptions
{
    public class LogicException(string message) : AppException(message)
    {
        public LogicException() : this(Resources.Messages.Validations.LogicException)
        {

        }
    }
}
