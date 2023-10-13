using Application.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Skip authorization [AllowAnonymous] attribute is present
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        // Authorization
        var user = (User) context.HttpContext.Items["User"];
        if (user == null) throw new UnauthorizedUserException("Unauthorized.");
    }
}