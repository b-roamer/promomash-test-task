using Application.Provinces.Commands;
using Application.Provinces.Models;
using Application.Provinces.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Attributes;

namespace WebAPI.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class ProvincesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProvincesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Province>>> GetAll()
    {
        var query = new GetAllProvinces();
        return Ok(await _mediator.Send(query));
    }

    [AllowAnonymous]
    [HttpGet("{provinceId}")]
    public async Task<ActionResult<Province>> GetById(Guid provinceId)
    {
        var query = new GetProvinceById(provinceId);
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult<Province>> CreateProvince([FromBody] CreateProvinceRequest request)
    {
        var command = new CreateProvince(request);
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<Province>> UpdateProvince([FromBody] UpdateProvinceRequest request)
    {
        var command = new UpdateProvince(request);
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{provinceId}")]
    public async Task<ActionResult<Province>> DeleteProvince(Guid provinceId)
    {
        var command = new DeleteProvince(provinceId);
        await _mediator.Send(command);

        return NoContent();
    }
}