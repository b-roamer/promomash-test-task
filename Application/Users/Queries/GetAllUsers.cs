using Domain.Entities;
using MediatR;

namespace Application.Users.Queries;

public class GetAllUsers : IRequest<IEnumerable<User>>
{
    
}