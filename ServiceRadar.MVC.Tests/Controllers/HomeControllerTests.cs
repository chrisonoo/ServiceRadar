using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace ServiceRadar.MVC.Controllers.Tests;

public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HomeControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact()]
    public async Task Privacy_ReturnsViewWithRenderModel()
    {
        // Arrange

        var client = _factory.CreateClient();

        // Act

        var response = await client.GetAsync("/Home/Privacy");

        // Assert

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();

        content.Should()
            .Contain("<h1>Privacy Policy</h1>")
            .And.Contain("<p>Privacy policy details:</p>")
            .And.Contain("<li>We do not collect or store personal information.</li>")
            .And.Contain("<li>Your privacy is our priority.</li>")
            .And.Contain("<li>No data sharing with third parties.</li>");
    }
}