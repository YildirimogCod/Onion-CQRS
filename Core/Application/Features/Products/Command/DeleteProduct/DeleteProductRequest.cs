using MediatR;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductRequest: IRequest
    {
        public int Id { get; set; }
    }
}
