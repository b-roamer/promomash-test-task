using Application.Users.Models;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> Authenticate(AuthRequest request);

    Task<AuthResponse> Register(CreateUserRequest request);
}