namespace WebAPI.Middleware;

public static class CustomMiddlewareExtensions
{
    public static void ConfigureCustomMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseMiddleware<JwtMiddleware>();
    }
}