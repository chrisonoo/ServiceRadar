using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Application.Workshops.Queries.GetAllWorkshops;
using System.Net;
using Xunit;

namespace ServiceRadar.MVC.Controllers.Tests;

public class WorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WorkshopControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact()]
    public async Task Index_ReturnsViewWithfExpectedData_ForExistingWorkshops()
    {
        // Arrange

        var workshops = new List<WorkshopDto>()
        {
            new WorkshopDto()
            {
                Name = "Workshop 1",
            },
            new WorkshopDto()
            {
                Name = "Workshop 2",
            },
            new WorkshopDto()
            {
                Name = "Workshop 3",
            },
        };

        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllWorkshopsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(workshops);

        var client = _factory
            .WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
            .CreateClient();

        // Act

        var response = await client.GetAsync("/Workshop/Index");

        // Assert

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();

        content.Should()
            .Contain("<h1>Workshops</h1>")
            .And.Contain("Workshop 1")
            .And.Contain("Workshop 2")
            .And.Contain("Workshop 3");
    }

    [Fact()]
    public async Task Index_ReturnsEmptyView_WhenNoWorkshopExist()
    {
        // Arrange

        var workshops = new List<WorkshopDto>();

        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<GetAllWorkshopsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(workshops);

        var client = _factory
            .WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
            .CreateClient();

        // Act

        var response = await client.GetAsync("/Workshop/Index");

        // Assert

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();

        content.Should().NotContain("class=\"card m-3\"");
    }
}