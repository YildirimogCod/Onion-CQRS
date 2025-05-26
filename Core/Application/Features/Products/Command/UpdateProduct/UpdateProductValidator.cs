using FluentValidation;

namespace Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductValidator: AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Product ID must be greater than zero.");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Product description is required.")
                .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage("It must be greater than 0");
            RuleFor(x => x.CategoryIds).Must(categories => categories.Any()).WithName("Categories");
        }
    }
}
