namespace Common.Exceptions;

public class ForbiddenAccessException(string message) : AppException(message)
{
    public ForbiddenAccessException() : this(message: Resources.Messages.Validations.ForbiddenAccessException) { }
}
