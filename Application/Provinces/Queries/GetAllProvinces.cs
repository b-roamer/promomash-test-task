using Domain.Entities;
using MediatR;

namespace Application.Provinces.Queries;

public class GetAllProvinces : IRequest<IEnumerable<Province>>
{
}