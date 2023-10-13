using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetUserById : IRequest<User>
{
    public GetUserById(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}