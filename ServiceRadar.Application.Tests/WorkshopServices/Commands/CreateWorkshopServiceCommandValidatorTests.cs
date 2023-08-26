using FluentValidation.TestHelper;
using Xunit;

namespace ServiceRadar.Application.WorkshopServices.Commands.Tests;

public class CreateWorkshopServiceCommandValidatorTests
{
    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveValidationError()
    {
        // Arrange

        var validator = new CreateWorkshopServiceCommandValidator();
        var command = new CreateWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            ServiceDescription = "Service Description",
            WorkshopEncodedName = "workshop-service"
        };

        // Act

        var result = validator.TestValidate(command);

        // Assert

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Validate_WithInvalidCommand_ShouldHaveValidationError()
    {
        // Arrange

        var validator = new CreateWorkshopServiceCommandValidator();
        var command = new CreateWorkshopServiceCommand()
        {
            Cost = "",
            ServiceDescription = "",
            WorkshopEncodedName = null
        };

        // Act

        var result = validator.TestValidate(command);

        // Assert

        result.ShouldHaveValidationErrorFor(c => c.Cost);
        result.ShouldHaveValidationErrorFor(c => c.ServiceDescription);
        result.ShouldHaveValidationErrorFor(c => c.WorkshopEncodedName);
    }
}