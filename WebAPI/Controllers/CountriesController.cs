using Application.Countries.Commands;
using Application.Countries.Models;
using Application.Countries.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Attributes;

namespace WebAPI.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetAll()
    {
        var query = new GetAllCountries();
        return Ok(await _mediator.Send(query));
    }

    [AllowAnonymous]
    [HttpGet("{countryId}")]
    public async Task<ActionResult<Country>> GetById(Guid countryId)
    {
        var query = new GetCountryById(countryId);
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult<Country>> CreateCountry([FromBody] CreateCountryRequest request)
    {
        var command = new CreateCountry(request);
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<Country>> UpdateCountry([FromBody] UpdateCountryRequest request)
    {
        var command = new UpdateCountry(request);
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{countryId}")]
    public async Task<ActionResult<Country>> DeleteCountry(Guid countryId)
    {
        var command = new DeleteCountry(countryId);
        await _mediator.Send(command);

        return NoContent();
    }
}