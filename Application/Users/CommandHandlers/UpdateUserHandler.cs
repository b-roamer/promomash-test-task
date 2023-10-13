using Application.Interfaces;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.CommandHandlers;

public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserId = request.UserId,
            Email = request.Email,
            CountryId = request.CountryId,
            ProvinceId = request.ProvinceId
        };

        return await _userRepository.Update(user);
    }
}