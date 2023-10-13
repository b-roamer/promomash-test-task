using MediatR;

namespace Application.Countries.Commands;

public class DeleteCountry : IRequest
{
    public DeleteCountry(Guid countryId)
    {
        CountryId = countryId;
    }

    public Guid CountryId { get; set; }
}