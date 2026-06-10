using FluentValidation;

namespace SmartSpaces.Application.Features.Spaces.Commands.CreateSpace;

public class CreateSpaceCommandValidator : AbstractValidator<CreateSpaceCommand>
{
    public CreateSpaceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del espacio no puede estar vacío.")
            .MaximumLength(100).WithMessage("El nombre no puede tener más de 100 caracteres.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("La capacidad debe ser mayor a 0.");
    }
}