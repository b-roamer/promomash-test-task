using Application.Countries.Models;
using Domain.Entities;
using MediatR;

namespace Application.Countries.Commands;

public class CreateCountry : IRequest<Country>
{
    public CreateCountry(CreateCountryRequest request)
    {
        Name = request.Name;
    }

    public string Name { get; set; }
}