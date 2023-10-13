using System.Net;

namespace Application.Exceptions;

public class UnauthorizedUserException : Exception
{
    public static HttpStatusCode StatusCode = HttpStatusCode.Unauthorized;

    public UnauthorizedUserException()
    {
    }

    public UnauthorizedUserException(string message) : base(message)
    {
    }

    public UnauthorizedUserException(string message, Exception innerException) : base(message, innerException)
    {
    }
}