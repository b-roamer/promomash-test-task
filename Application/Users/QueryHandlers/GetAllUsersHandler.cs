using Application.Interfaces;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;   
    }
    
    public async Task<IEnumerable<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAll();
    }
}