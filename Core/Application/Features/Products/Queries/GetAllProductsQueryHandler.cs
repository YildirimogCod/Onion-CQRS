using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler:IRequestHandler<GetAllProductQueryRequest,IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
          var products =  await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
          List<GetAllProductQueryResponse> response = new();
          foreach (var product in products)
          {
              response.Add(new GetAllProductQueryResponse
              {
                  Title = product.Title,
                  Description = product.Description,
                  Discount = product.Discount,
                  Price = product.Price - (product.Price * product.Discount / 100)
              });
          }
            return response;
        }
    }
}
