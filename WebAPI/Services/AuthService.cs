using Application.Exceptions;
using Application.Interfaces;
using Application.Users.Commands;
using Application.Users.Models;
using Application.Users.Queries;
using MediatR;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IJwtService _jwtService;
    private readonly IMediator _mediator;

    public AuthService(IMediator mediator, IJwtService jwtService)
    {
        _mediator = mediator;
        _jwtService = jwtService;
    }

    public async Task<AuthResponse> Authenticate(AuthRequest request)
    {
        var user = await _mediator.Send(new GetUserByEmail(request.Email));

        // Validate password
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password + user.PasswordSalt, user.PasswordHash))
            throw new UnauthorizedUserException("Username or password is incorrect");

        // Authentication is successful
        var response = new AuthResponse(user, _jwtService.GenerateJwtToken(user));
        return response;
    }

    public async Task<AuthResponse> Register(CreateUserRequest request)
    {
        if (!IsValidPassword(request.Password))
            throw new ArgumentException(
                "Password must be at least 6 characters long and contain min 1 digit and min 1 letter.");

        // Salting and Hashing the password
        var passwordSalt = Guid.NewGuid().ToString();
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password + passwordSalt);

        var user = await _mediator.Send(new CreateUser(request, passwordSalt, passwordHash));

        // Generating access token after successful registration
        var response = new AuthResponse(user, _jwtService.GenerateJwtToken(user));
        return response;
    }

    private static bool IsValidPassword(string password)
    {
        return password.Length >= 6
               && password.Any(char.IsDigit)
               && password.Any(char.IsLetter);
    }
}