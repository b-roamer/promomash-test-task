using Application.Provinces.Models;
using Domain.Entities;
using MediatR;

namespace Application.Provinces.Commands;

public class UpdateProvince : IRequest<Province>
{
    public UpdateProvince(UpdateProvinceRequest request)
    {
        ProvinceId = request.ProvinceId;
        CountryId = request.CountryId;
        Name = request.Name;
    }

    public Guid ProvinceId { get; set; }

    public Guid CountryId { get; set; }

    public string Name { get; set; }
}