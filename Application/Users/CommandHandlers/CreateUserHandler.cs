using Application.Interfaces;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.CommandHandlers;

public class CreateUserHandler : IRequestHandler<CreateUser, User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            Email = request.Email,
            PasswordSalt = request.PasswordSalt,
            PasswordHash = request.PasswordHash,
            CountryId = request.CountryId,
            ProvinceId = request.ProvinceId
        };

        return await _userRepository.Insert(newUser);
    }
}