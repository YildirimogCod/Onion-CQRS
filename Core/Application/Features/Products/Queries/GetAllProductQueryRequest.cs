using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetAllProductQueryRequest:IRequest<IList<GetAllProductQueryResponse>>
    {
    }
}
