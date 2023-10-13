using Application.Countries.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Countries.QueryHandlers;

public class GetAllCountriesHandler : IRequestHandler<GetAllCountries, IEnumerable<Country>>
{
    private readonly ICountryRepository _countryRepository;

    public GetAllCountriesHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<Country>> Handle(GetAllCountries request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetAll();
    }
}