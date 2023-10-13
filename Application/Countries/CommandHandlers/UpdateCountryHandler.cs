using Application.Countries.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Countries.CommandHandlers;

public class UpdateCountryHandler : IRequestHandler<UpdateCountry, Country>
{
    private readonly ICountryRepository _countryRepository;

    public UpdateCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            CountryId = request.CountryId,
            Name = request.Name
        };

        return await _countryRepository.Update(country);
    }
}