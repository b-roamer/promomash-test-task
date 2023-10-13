using Application.Interfaces;
using Application.Provinces.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Provinces.QueryHandlers;

public class GetProvinceByIdHandler : IRequestHandler<GetProvinceById, Province>
{
    private readonly IProvinceRepository _provinceRepository;

    public GetProvinceByIdHandler(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<Province> Handle(GetProvinceById request, CancellationToken cancellationToken)
    {
        return await _provinceRepository.GetById(request.ProvinceId);
    }
}