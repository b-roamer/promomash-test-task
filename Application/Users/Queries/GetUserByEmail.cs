using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetUserByEmail : IRequest<User>
{
    public GetUserByEmail(string email)
    {
        Email = email;
    }

    public string Email { get; set; }
}