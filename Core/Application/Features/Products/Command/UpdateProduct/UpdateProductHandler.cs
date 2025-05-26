using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductHandler:IRequestHandler<UpdateProductRequest,Unit>
    {
        // Inject any required services here, e.g., a repository or a database context
        private readonly IUnitOfWork _unitOfWork;
        private  readonly IMapper _mapper;
        public UpdateProductHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = _mapper.Map<Product,UpdateProductRequest>(request);
            var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x =>  x.ProductId == product.Id);
            await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);
            foreach (var categoryId in request.CategoryIds )
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId,
                    ProductId = product.Id
                };
                await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(productCategory); 

            }
            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value; // Return Unit.Value to indicate successful completion

        }
    }
}
