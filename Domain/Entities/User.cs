using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User : EntityBase
{
    public Guid UserId { get; set; }

    public string Email { get; set; }

    public Guid? CountryId { get; set; }

    public Country? Country { get; set; }

    public Guid? ProvinceId { get; set; }

    public Province? Province { get; set; }

    [JsonIgnore] public string PasswordHash { get; set; }

    [JsonIgnore] public string PasswordSalt { get; set; }
}