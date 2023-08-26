using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Xunit;

namespace ServiceRadar.Application.Common.ApplicationUser.Tests;

public class UserContextTests
{
    [Fact]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        // Arrange

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Email, "test@example.com"),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "User"),
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });

        var userContext = new UserContext(httpContextAccessorMock.Object);

        // Act

        var currentUser = userContext.GetCurrentUser();

        // Assert

        currentUser.Should().NotBeNull();
        currentUser!.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@example.com");
        currentUser.Roles.Should().ContainInOrder("Admin", "User");
    }
}