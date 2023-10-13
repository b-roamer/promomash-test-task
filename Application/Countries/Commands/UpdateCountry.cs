using Application.Countries.Models;
using Domain.Entities;
using MediatR;

namespace Application.Countries.Commands;

public class UpdateCountry : IRequest<Country>
{
    public UpdateCountry(UpdateCountryRequest request)
    {
        CountryId = request.CountryId;
        Name = request.Name;
    }

    public Guid CountryId { get; set; }

    public string Name { get; set; }
}