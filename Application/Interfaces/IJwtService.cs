using Domain.Entities;

namespace Application.Interfaces;

public interface IJwtService
{
    public string GenerateJwtToken(User user);

    public Guid? ValidateJwtToken(string token);
}