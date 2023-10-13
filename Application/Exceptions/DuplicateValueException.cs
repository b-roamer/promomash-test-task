using System.Net;

namespace Application.Exceptions;

public class DuplicateValueException : Exception
{
    public static HttpStatusCode StatusCode = HttpStatusCode.Conflict;

    public DuplicateValueException()
    {
    }

    public DuplicateValueException(string message) : base(message)
    {
    }

    public DuplicateValueException(string message, Exception innerException) : base(message, innerException)
    {
    }
}