using Application.Interfaces;
using Application.Provinces.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Provinces.QueryHandlers;

public class GetAllProvincesHandler : IRequestHandler<GetAllProvinces, IEnumerable<Province>>
{
    private readonly IProvinceRepository _provinceRepository;

    public GetAllProvincesHandler(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<IEnumerable<Province>> Handle(GetAllProvinces request, CancellationToken cancellationToken)
    {
        return await _provinceRepository.GetAll();
    }
}