using SmartSpaces.Application.Features.Spaces.Commands.CreateSpace;
using Xunit;

namespace SmartSpaces.UnitTests;

public class CreateSpaceValidatorTests
{
    private readonly CreateSpaceCommandValidator _validator;

    public CreateSpaceValidatorTests()
    {
        // Inicializamos el validador real de la capa Application
        _validator = new CreateSpaceCommandValidator();
    }

    [Fact]
    public void Validator_ShouldHaveError_WhenCapacityIsZeroOrLess()
    {
        // 1. Arrange (Preparar el escenario con capacidad inválida)
        var command = new CreateSpaceCommand("Laboratorio Alfa", 0);

        // 2. Act (Ejecutar la validación)
        var result = _validator.Validate(command);

        // 3. Assert (Verificar que falló tal como esperábamos)
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "Capacity");
    }

    [Fact]
    public void Validator_ShouldBeValid_WhenDataIsCorrect()
    {
        // 1. Arrange (Datos correctos)
        var command = new CreateSpaceCommand("Aula 204", 35);

        // 2. Act
        var result = _validator.Validate(command);

        // 3. Assert
        Assert.True(result.IsValid);
    }
}