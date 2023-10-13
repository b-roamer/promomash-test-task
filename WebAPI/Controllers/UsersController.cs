using Application.Interfaces;
using Application.Users.Models;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Attributes;

namespace WebAPI.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator, IAuthService authService)
    {
        _mediator = mediator;
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] CreateUserRequest request)
    {
        return Ok(await _authService.Register(request));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
    {
        return Ok(await _authService.Authenticate(request));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllUsers()));
    }
}