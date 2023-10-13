using Domain.Entities;
using MediatR;

namespace Application.Provinces.Queries;

public class GetProvinceById : IRequest<Province>
{
    public GetProvinceById(Guid provinceId)
    {
        ProvinceId = provinceId;
    }

    public Guid ProvinceId { get; set; }
}