using Application.Bases;
using Application.Features.Auth.Rules;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler:BaseHandler,IRequestHandler<RegisterCommandRequest,Unit>
    {
        private readonly AuthRule _authRule;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, AuthRule authRule,UserManager<User> userManager,RoleManager<Role> roleManager) : base(unitOfWork, mapper, httpContextAccessor )
        {
            _authRule = authRule;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _authRule.UserShouldNotBeExis(await _userManager.FindByEmailAsync(request.Email));
            User user = _mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.FirstName = request.FullName;
            user.SecurityStamp = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("user"))
                    await _roleManager.CreateAsync(new Role {Id = Guid.NewGuid(),Name = "user",NormalizedName = "USER",ConcurrencyStamp = Guid.NewGuid().ToString()});

                await _userManager.AddToRoleAsync(user, "user");
            }
            return Unit.Value;

        }
    }
}
