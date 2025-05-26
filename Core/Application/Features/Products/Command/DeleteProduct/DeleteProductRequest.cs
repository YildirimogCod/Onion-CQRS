using MediatR;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductRequest: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
