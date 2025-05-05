using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetAllProductQueryResponse:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }


    }
}
