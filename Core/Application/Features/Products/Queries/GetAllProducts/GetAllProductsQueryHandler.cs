using Application.DTOs;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler:IRequestHandler<GetAllProductQueryRequest,IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
          var products =  await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x => x.Include(b => b.Brand));
          var brand = _mapper.Map<BrandDto, Brand>(new Brand());
          #region before automapper

          // foreach (var product in products)
          // {
          //     response.Add(new GetAllProductQueryResponse
          //     {
          //         Title = product.Title,
          //         Description = product.Description,
          //         Discount = product.Discount,
          //         Price = product.Price - product.Price * product.Discount / 100
          //     });
          // }

          #endregion
          var map = _mapper.Map<GetAllProductQueryResponse,Product>(products);
          foreach (var item in map)
          {
              item.Price -= (item.Price * item.Discount / 100);
          }
            return map;
        }
    }
}
