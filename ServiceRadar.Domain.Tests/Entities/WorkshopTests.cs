using FluentAssertions;
using Xunit;

namespace ServiceRadar.Domain.Entities.Tests;

public class WorkshopTests
{
    [Fact]
    public void EncodeName_ShouldSetEncodedName()
    {
        // Arrange

        var workshop = new Workshop();
        workshop.Name = "Test Workshop";

        // Act

        workshop.EncodeName();

        // Assert

        workshop.EncodedName.Should().Be("test-workshop");
    }

    [Fact]
    public void EncodedName_ShouldThrowException_WhenNameIsNull()
    {
        // Arrange

        var workshop = new Workshop();

        // Act

        Action action = () => workshop.EncodeName();

        // Assert

        action.Invoking(a => a.Invoke())
            .Should().Throw<NullReferenceException>();
    }
}