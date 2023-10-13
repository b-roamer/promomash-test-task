using Application.Users.Models;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class CreateUser : IRequest<User>
{
    public CreateUser(CreateUserRequest request, string passwordSalt, string passwordHash)
    {
        Email = request.Email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        CountryId = request.CountryId;
        ProvinceId = request.ProvinceId;
    }

    public string Email { get; set; }

    public string PasswordSalt { get; set; }

    public string PasswordHash { get; set; }

    public Guid CountryId { get; set; }

    public Guid ProvinceId { get; set; }
}