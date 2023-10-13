using Application.Interfaces;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmail, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByEmail request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByEmail(request.Email);
    }
}