using Application.Bases;

namespace Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException:BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Title must not be same")
        {

        }
      
    }
}
