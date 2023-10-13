using Application.Countries.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Countries.QueryHandlers;

public class GetCountryByIdHandler : IRequestHandler<GetCountryById, Country>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountryByIdHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country> Handle(GetCountryById request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetById(request.CountryId);
    }
}