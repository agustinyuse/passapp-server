using MediatR;
using Domain.Shared;
using FluentValidation;

namespace Application.Behaviours;

public class ValidationPipelineBehaviours<TRequest, TResponse> : IPipelineBehaviour<TRequest, TResponse>
where TRequest : IRequest<TResponse>
where TResponse : Result
{
  private readonly IEnumerable<IValidator<TRequest>> _validators;

  public ValidationPipelineBehaviours(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

  public async Task<TResponse> Handle(TRequest request,
    CancellationToken cancellationToken,
    RequestHandlerDelegate<TResponse> next)
  {

    if (!_validators.Any())
    {
      return await next();
    }

    Error[] errors = _validators
                                .Select(validator => validator.Validate(request))
                                .SelectMany(validationResult => validationResult.Errors)
                                .Where(validationFailure => validationFailure is not null)
                                .Select(validationFailure => new Error(validationFailure.ErrorCode, validationFailure.ErrorMessage))
                                .Distinct()
                                .ToArray();

    if (errors.Any())
    {
      //return validation Result
    }

    return await next();
  }

  public static TResult CreateValidationResult<TResult>(Error[] errors) where TResult : Result
  {
    if (typeof(TResult) == typeof(Result))
    {
      return (ValidationResult.WithErrors(errors) as TResult)!;
    }

    typeof(ValidationResult<>)
      .GetGenericTypeDefinition()
      .MakeGenericType(typeof(TResult).GetGenericArguments()[0])
      .GetMethod(nameof(ValidationResult.WithErrors))!
      .Invoke(null, new object?[] { errors })!;

    return (TResult)validationResult;
  }

}

