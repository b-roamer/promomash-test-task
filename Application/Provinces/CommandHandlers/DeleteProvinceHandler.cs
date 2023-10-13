using Application.Interfaces;
using Application.Provinces.Commands;
using MediatR;

namespace Application.Provinces.CommandHandlers;

public class DeleteProvinceHandler : IRequestHandler<DeleteProvince>
{
    private readonly IProvinceRepository _provinceRepository;

    public DeleteProvinceHandler(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task Handle(DeleteProvince request, CancellationToken cancellationToken)
    {
        await _provinceRepository.Delete(request.ProvinceId);
    }
}