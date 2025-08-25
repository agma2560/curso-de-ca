using FluentValidation;
using MediatR;

namespace AppGan.UseCases.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var Failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (Failures.Any())
            {
                throw new ValidationException(Failures);
            }
            return next();
        }
    }
}
