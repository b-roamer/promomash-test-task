using Application.Interfaces;
using Application.Provinces.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Provinces.CommandHandlers;

public class UpdateProvinceHandler : IRequestHandler<UpdateProvince, Province>
{
    private readonly IProvinceRepository _provinceRepository;

    public UpdateProvinceHandler(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<Province> Handle(UpdateProvince request, CancellationToken cancellationToken)
    {
        var province = new Province
        {
            ProvinceId = request.ProvinceId,
            CountryId = request.CountryId,
            Name = request.Name
        };

        return await _provinceRepository.Update(province);
    }
}