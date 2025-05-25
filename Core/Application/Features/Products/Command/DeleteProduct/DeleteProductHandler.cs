using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductHandler: IRequestHandler<DeleteProductRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (product == null)
            {
                throw new Exception("Product not found or already deleted.");
            }
            product.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
