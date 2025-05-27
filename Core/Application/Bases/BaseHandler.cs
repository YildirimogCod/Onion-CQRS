using System.Security.Claims;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Bases
{
    public class BaseHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly string _userId;

        public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            // Extract user ID from the HTTP context if available
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
