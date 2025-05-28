using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Bases;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.Tokens;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler:BaseHandler,IRequestHandler<RefreshTokenCommandRequest,RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommandHandler(UserManager<User> userManager,ITokenService tokenService,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            IList<string> roles =await  userManager.GetRolesAsync(user);
            if(user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new Exception("Refresh token expired");
            }
            JwtSecurityToken newAccessToken = await tokenService.GenerateAccessTokenAsync(user, roles);
            string newRefreshToken = tokenService.RefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await userManager.UpdateAsync(user);
            return new RefreshTokenCommandResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}
