using FluentValidation;
using MediatR;

namespace SmartSpaces.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    // Inyectamos todos los validadores que existan en la capa Application
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            // Ejecuta todas las validaciones en paralelo
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            // Junta todos los errores encontrados
            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            // SI HAY ERRORES: Lanza una excepción de validación y frena el flujo
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }

        // SI NO HAY ERRORES: Continúa hacia el Handler correspondiente
        return await next();
    }
}