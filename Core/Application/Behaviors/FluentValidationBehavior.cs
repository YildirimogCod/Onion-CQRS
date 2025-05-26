using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class FluentValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest:IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = _validator.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .GroupBy(x=>x.ErrorMessage)
                .Select(x => x.First())
                .Where(x => x != null)
                .ToList();
            if (failtures.Any())
            {
                throw new ValidationException(failtures);
            }
            return next();
        }
    }
}
