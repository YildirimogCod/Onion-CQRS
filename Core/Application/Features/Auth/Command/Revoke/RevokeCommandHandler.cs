using Application.Bases;
using Application.Features.Auth.Rules;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler:BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthRule _authRule;
        public RevokeCommandHandler(UserManager<User> userManager,AuthRule authRule,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
            _userManager = userManager;
            _authRule = authRule;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);
            await _authRule.EmailAdressSouldBeValid(user);
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            return Unit.Value;

        }
    }
}
