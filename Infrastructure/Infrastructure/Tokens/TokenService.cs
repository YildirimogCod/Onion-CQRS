using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Interfaces.Tokens;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Tokens
{
    public class TokenService:ITokenService
    {
        private readonly TokenSettings _tokenSettings;
        private readonly UserManager<User> _userManager;

        public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
        {
            _tokenSettings = options.Value;
            _userManager = userManager;
        }
        public async Task<JwtSecurityToken> GenerateAccessTokenAsync(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenSettings.TokenExpirationInMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            await _userManager.AddClaimsAsync(user, claims);
            return token;

        }

        public string RefreshToken()
        {
            var random = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);
            return Convert.ToBase64String(random);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
           TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidIssuer = _tokenSettings.Issuer,
               ValidateAudience = false,
               ValidAudience = _tokenSettings.Audience,
               ValidateLifetime = false, // We are checking the expiration manually
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey)),
               ValidateIssuerSigningKey = true
           };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return principal;
            }
            throw new SecurityTokenException("Invalid token");

        }
    }
}
