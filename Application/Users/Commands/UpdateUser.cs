using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class UpdateUser : IRequest<User>
{
    public UpdateUser(User user)
    {
        UserId = user.UserId;
        Email = user.Email;
        CountryId = user.CountryId;
        ProvinceId = user.ProvinceId;
    }

    public Guid UserId { get; set; }

    public string Email { get; set; }

    public Guid? CountryId { get; set; }

    public Guid? ProvinceId { get; set; }
}