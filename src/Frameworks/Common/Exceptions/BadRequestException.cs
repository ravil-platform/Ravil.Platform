using System;

namespace Common.Exceptions
{
    public class BadRequestException(string message) : AppException(message)
    {
      
    }
}
