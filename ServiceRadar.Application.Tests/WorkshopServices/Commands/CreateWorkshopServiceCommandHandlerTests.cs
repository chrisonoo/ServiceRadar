using Moq;
using ServiceRadar.Application.Common.ApplicationUser;
using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;
using Xunit;

namespace ServiceRadar.Application.WorkshopServices.Commands.Tests;

public class CreateWorkshopServiceCommandHandlerTests
{
    [Fact]
    public async Task Handle_CreatesWorkshopService_WhenUserIsAuthorized()
    {
        // Arrange

        var workshop = new Workshop()
        {
            Id = 1,
            CreateById = "1",
        };

        var command = new CreateWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            ServiceDescription = "Service Description",
            WorkshopEncodedName = "workshop-service"
        };

        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

        var workshopRepositoryMock = new Mock<IServiceRadarRepository>();
        workshopRepositoryMock.Setup(c => c.GetWorkshopByEncodedName(command.WorkshopEncodedName))
            .ReturnsAsync(workshop);

        var workshopServiceRepositoryMock = new Mock<IWorkshopServiceRepository>();

        var handler = new CreateWorkshopServiceCommandHandler(workshopRepositoryMock.Object, userContextMock.Object, workshopServiceRepositoryMock.Object);

        // Act

        await handler.Handle(command, CancellationToken.None);

        // Assert

        workshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<WorkshopService>()), Times.Once);
    }

    [Fact]
    public async Task Handle_CreatesWorkshopService_WhenUserIsRedactor()
    {
        // Arrange

        var workshop = new Workshop()
        {
            Id = 1,
            CreateById = "1",
        };

        var command = new CreateWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            ServiceDescription = "Service Description",
            WorkshopEncodedName = "workshop-service"
        };

        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@test.com", new[] { "Redactor" }));

        var workshopRepositoryMock = new Mock<IServiceRadarRepository>();
        workshopRepositoryMock.Setup(c => c.GetWorkshopByEncodedName(command.WorkshopEncodedName))
            .ReturnsAsync(workshop);

        var workshopServiceRepositoryMock = new Mock<IWorkshopServiceRepository>();

        var handler = new CreateWorkshopServiceCommandHandler(workshopRepositoryMock.Object, userContextMock.Object, workshopServiceRepositoryMock.Object);

        // Act

        await handler.Handle(command, CancellationToken.None);

        // Assert

        workshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<WorkshopService>()), Times.Once);
    }

    [Fact]
    public async Task Handle_DoesntCreateWorkshopService_WhenUserIsNotAuthorised()
    {
        // Arrange

        var workshop = new Workshop()
        {
            Id = 1,
            CreateById = "1",
        };

        var command = new CreateWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            ServiceDescription = "Service Description",
            WorkshopEncodedName = "workshop-service"
        };

        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@test.com", new[] { "User" }));

        var workshopRepositoryMock = new Mock<IServiceRadarRepository>();
        workshopRepositoryMock.Setup(c => c.GetWorkshopByEncodedName(command.WorkshopEncodedName))
            .ReturnsAsync(workshop);

        var workshopServiceRepositoryMock = new Mock<IWorkshopServiceRepository>();

        var handler = new CreateWorkshopServiceCommandHandler(workshopRepositoryMock.Object, userContextMock.Object, workshopServiceRepositoryMock.Object);

        // Act

        await handler.Handle(command, CancellationToken.None);

        // Assert

        workshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<WorkshopService>()), Times.Never);
    }

    [Fact]
    public async Task Handle_DoesntCreateWorkshopService_WhenUserIsNotAuthenticated()
    {
        // Arrange

        var workshop = new Workshop()
        {
            Id = 1,
            CreateById = "1",
        };

        var command = new CreateWorkshopServiceCommand()
        {
            Cost = "100 PLN",
            ServiceDescription = "Service Description",
            WorkshopEncodedName = "workshop-service"
        };

        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(c => c.GetCurrentUser())
            .Returns((CurrentUser?)null);

        var workshopRepositoryMock = new Mock<IServiceRadarRepository>();
        workshopRepositoryMock.Setup(c => c.GetWorkshopByEncodedName(command.WorkshopEncodedName))
            .ReturnsAsync(workshop);

        var workshopServiceRepositoryMock = new Mock<IWorkshopServiceRepository>();

        var handler = new CreateWorkshopServiceCommandHandler(workshopRepositoryMock.Object, userContextMock.Object, workshopServiceRepositoryMock.Object);

        // Act

        await handler.Handle(command, CancellationToken.None);

        // Assert

        workshopServiceRepositoryMock.Verify(m => m.Create(It.IsAny<WorkshopService>()), Times.Never);
    }
}