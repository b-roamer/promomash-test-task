using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Services;

public class JwtService : IJwtService
{
    private readonly IMediator _mediator;
    private readonly string _secret;

    public JwtService(IConfiguration configuration, IMediator mediator)
    {
        _secret = configuration.GetValue<string>("Auth:Secret")
                  ?? throw new ApplicationException("Auth Secret is null.");
        _mediator = mediator;
    }

    /// <summary>
    ///     Generating JWT Token that is valid for 1 day
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string GenerateJwtToken(User user)
    {
        // Generate token that is valid for 1 day
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("userId", user.UserId.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    ///     Validating JWT Token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Guid? ValidateJwtToken(string token)
    {
        if (string.IsNullOrEmpty(token)) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken) validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "userId").Value);

            return userId;
        }
        catch
        {
            return null;
        }
    }
}