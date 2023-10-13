using Domain.Entities;

namespace Application.Users.Models;

public class AuthResponse
{
    public AuthResponse(User user, string accessToken)
    {
        UserId = user.UserId;
        Email = user.Email;
        CountryId = user.CountryId;
        ProvinceId = user.ProvinceId;
        AccessToken = accessToken;
    }

    public Guid UserId { get; set; }

    public string Email { get; set; }

    public Guid? CountryId { get; set; }

    public Guid? ProvinceId { get; set; }

    public string AccessToken { get; set; }
}