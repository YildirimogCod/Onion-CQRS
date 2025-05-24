using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductQueryResponse:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public BrandDto Brand { get; set; }


    }
}
