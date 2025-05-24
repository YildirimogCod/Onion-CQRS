using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductQueryRequest:IRequest<IList<GetAllProductQueryResponse>>
    {
    }
}
