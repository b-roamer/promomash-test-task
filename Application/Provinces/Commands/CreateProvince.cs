using Application.Provinces.Models;
using Domain.Entities;
using MediatR;

namespace Application.Provinces.Commands;

public class CreateProvince : IRequest<Province>
{
    public CreateProvince(CreateProvinceRequest request)
    {
        Name = request.Name;
        CountryId = request.CountryId;
    }

    public string Name { get; set; }

    public Guid CountryId { get; set; }
}