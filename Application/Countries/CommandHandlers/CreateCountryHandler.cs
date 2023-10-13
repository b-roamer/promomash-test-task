using Application.Countries.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Countries.CommandHandlers;

public class CreateCountryHandler : IRequestHandler<CreateCountry, Country>
{
    private readonly ICountryRepository _countryRepository;

    public CreateCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country> Handle(CreateCountry request, CancellationToken cancellationToken)
    {
        var newCountry = new Country
        {
            Name = request.Name
        };

        return await _countryRepository.Insert(newCountry);
    }
}