using Application.Bases;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Command.RevokeAll
{
    public class RevokeAllCommandHandler:BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        public RevokeAllCommandHandler(UserManager<User> userManager,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            IList<User> users = await _userManager.Users.ToListAsync(cancellationToken);
            foreach (User user in users)
            {
              user.RefreshToken = null;
              await _userManager.UpdateAsync(user);
            }
            return Unit.Value;
        }
    }
}
