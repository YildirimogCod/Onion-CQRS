using Application.Bases;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductHandler:BaseHandler, IRequestHandler<DeleteProductRequest, Unit>
    {
        public DeleteProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (product == null)
            {
                throw new Exception("Product not found or already deleted.");
            }
            product.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value; // Return Unit.Value to indicate successful completion
        }
    }
}
