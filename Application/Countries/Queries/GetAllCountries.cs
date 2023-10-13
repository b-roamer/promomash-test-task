using Domain.Entities;
using MediatR;

namespace Application.Countries.Queries;

public class GetAllCountries : IRequest<IEnumerable<Country>>
{
}