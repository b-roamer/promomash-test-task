using Domain.Entities;
using MediatR;

namespace Application.Countries.Queries;

public class GetCountryById : IRequest<Country>
{
    public GetCountryById(Guid countryId)
    {
        CountryId = countryId;
    }

    public Guid CountryId { get; set; }
}