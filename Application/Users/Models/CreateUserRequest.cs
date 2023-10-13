namespace Application.Users.Models;

public class CreateUserRequest
{
    public string Email { get; set; }

    public string Password { get; set; }

    public Guid CountryId { get; set; }

    public Guid ProvinceId { get; set; }
}