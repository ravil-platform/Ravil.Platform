namespace Common.Exceptions;

public class LockedOutException(string message) : AppException(message)
{
    public LockedOutException() : this(message: Resources.Messages.Validations.LockedOutException) { }
}