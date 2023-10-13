using MediatR;

namespace Application.Provinces.Commands;

public class DeleteProvince : IRequest
{
    public DeleteProvince(Guid provinceId)
    {
        ProvinceId = provinceId;
    }

    public Guid ProvinceId { get; set; }
}