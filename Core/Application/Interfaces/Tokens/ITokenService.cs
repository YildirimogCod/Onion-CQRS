using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Entities;

namespace Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenerateAccessTokenAsync(User user,IList<string> roles);
        string RefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
