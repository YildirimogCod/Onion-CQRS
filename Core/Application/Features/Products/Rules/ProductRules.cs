using Application.Bases;
using Application.Features.Products.Exceptions;
using Domain.Entities;

namespace Application.Features.Products.Rules
{
    public class ProductRules:BaseRule
    {
        public Task ProductTitleMustNotBeSameAsync(IList<Product> products, string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle))
            {
                throw new ProductTitleMustNotBeSameException();
            }
            return Task.CompletedTask;
        }
    }
}
