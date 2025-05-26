using Application.Features.Products.Rules;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command.CreateProduct
{
    public class CreateProductHandler:IRequestHandler<CreateProductRequest,Unit>
    {
        // Inject any required services, such as a repository or unit of work
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules _productRules;
        public CreateProductHandler(IUnitOfWork unitOfWork,ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            _productRules = productRules;

        }
        public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
            // Check if a product with the same title already exists

            await _productRules.ProductTitleMustNotBeSameAsync(products, request.Title);
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
            return Unit.Value; // Return Unit.Value to indicate successful completion
        }
    }
}
