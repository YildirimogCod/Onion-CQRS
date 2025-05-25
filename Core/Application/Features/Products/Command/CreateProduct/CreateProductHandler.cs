using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command.CreateProduct
{
    public class CreateProductHandler:IRequestHandler<CreateProductRequest>
    {
        // Inject any required services, such as a repository or unit of work
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Title,request.Description,request.BrandId,request.Price,request.Discount);
            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await _unitOfWork.SaveChangesAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id
                    });
                    await _unitOfWork.SaveChangesAsync();
                }
            } 
        }
    }
}
