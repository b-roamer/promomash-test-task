using Application.Interfaces;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetById(request.UserId);
    }
}