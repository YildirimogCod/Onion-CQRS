using System.IdentityModel.Tokens.Jwt;
using Application.Bases;
using Application.Features.Auth.Rules;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.Tokens;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler:BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration configuration;
        private readonly AuthRule _authRule;
        public LoginCommandHandler(UserManager<User> userManager,RoleManager<Role> roleManager,AuthRule authRule,ITokenService tokenService,IConfiguration configuration ,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.userManager = userManager;
            _authRule = authRule;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.tokenService = tokenService;

        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user,request.Password);
            await _authRule.EmailOrPasswordShoulNotBeInvalid(user, checkPassword);
            IList<string> roles = await userManager.GetRolesAsync(user);
            JwtSecurityToken token = await tokenService.GenerateAccessTokenAsync(user, roles);
            string refreshToken = tokenService.RefreshToken();
            _ = int.TryParse(configuration["JWT:RefreshTokenExpirationInDays"], out int refreshTokenValidityInDays);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);
            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);
            return new LoginCommandResponse
            {
                Token = _token,
                RefreshToken = refreshToken,
                TokenExpiration = token.ValidTo
            };
        }
    }
}
