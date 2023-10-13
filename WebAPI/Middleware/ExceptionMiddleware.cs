using System.Net;
using Application.Exceptions;
using Serilog;

namespace WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            Log.Error($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var errorDetails = new ErrorDetails();

        switch (exception)
        {
            case EntityNotFoundException e:
                context.Response.StatusCode = (int) EntityNotFoundException.StatusCode;
                break;

            case DuplicateValueException e:
                context.Response.StatusCode = (int) DuplicateValueException.StatusCode;
                break;

            case UnauthorizedUserException e:
                context.Response.StatusCode = (int) UnauthorizedUserException.StatusCode;
                break;

            case ArgumentException e:
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                break;

            default:
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                break;
        }

        await context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }
}