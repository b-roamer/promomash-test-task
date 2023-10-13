using Application.Interfaces;
using Application.Users.Queries;
using MediatR;

namespace WebAPI.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IMediator mediator, IJwtService jwtService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtService.ValidateJwtToken(token);
        if (userId != null)
            // Attach user to context on successful token validation
            context.Items["User"] = await mediator.Send(new GetUserById(userId.Value));

        await _next(context);
    }
}