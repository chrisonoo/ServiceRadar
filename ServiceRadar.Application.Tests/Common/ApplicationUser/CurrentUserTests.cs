using FluentAssertions;
using Xunit;

namespace ServiceRadar.Application.Common.ApplicationUser.Tests;

public class CurrentUserTests
{
    [Fact]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        // Arrange

        var currentUser = new CurrentUser("1", "user@test.com", new List<string> { "Admin", "User" });

        // Act

        var isInRole = currentUser.IsInRole("Admin");

        // Assert

        isInRole.Should().BeTrue();
    }

    [Fact]
    public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
    {
        // Arrange

        var currentUser = new CurrentUser("1", "user@test.com", new List<string> { "Admin", "User" });

        // Act

        var isInRole = currentUser.IsInRole("Redactor");

        // Assert

        isInRole.Should().BeFalse();
    }


    [Fact]
    public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
    {
        // Arrange

        var currentUser = new CurrentUser("1", "user@test.com", new List<string> { "Admin", "User" });

        // Act

        var isInRole = currentUser.IsInRole("admin");

        // Assert

        isInRole.Should().BeFalse();
    }
}