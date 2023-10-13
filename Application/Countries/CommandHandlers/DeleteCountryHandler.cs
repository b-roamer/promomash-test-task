using Application.Countries.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Countries.CommandHandlers;

public class DeleteCountryHandler : IRequestHandler<DeleteCountry>
{
    private readonly ICountryRepository _countryRepository;

    public DeleteCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task Handle(DeleteCountry request, CancellationToken cancellationToken)
    {
        await _countryRepository.Delete(request.CountryId);
    }
}