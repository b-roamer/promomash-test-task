using Application.Interfaces;
using Application.Provinces.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Provinces.CommandHandlers;

public class CreateProvinceHandler : IRequestHandler<CreateProvince, Province>
{
    private readonly IProvinceRepository _provinceRepository;

    public CreateProvinceHandler(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<Province> Handle(CreateProvince request, CancellationToken cancellationToken)
    {
        var newProvince = new Province
        {
            Name = request.Name,
            CountryId = request.CountryId
        };

        return await _provinceRepository.Insert(newProvince);
    }
}