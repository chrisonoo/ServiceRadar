using AutoMapper;
using FluentAssertions;
using Moq;
using ServiceRadar.Application.Common.ApplicationUser;
using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Entities;
using Xunit;

namespace ServiceRadar.Application.Workshops.Mappings.Tests;

public class WorkshopMappingProfileTests
{
    [Fact]
    public void MappingProfile_ShouldMapWorkshopDtoToWorkshop()
    {
        // Arrange

        var userContextMock = new Mock<IUserContext>();
        userContextMock
            .Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new WorkshopMappingProfile(userContextMock.Object)));

        var mapper = configuration.CreateMapper();

        var workshopDto = new WorkshopDto
        {
            City = "City",
            PhoneNumber = "123456789",
            PostalCode = "12345",
            Street = "Street"
        };

        // Act

        var result = mapper.Map<Workshop>(workshopDto);

        // Assert

        result.Should().NotBeNull();
        result.ContactDetails.Should().NotBeNull();
        result.ContactDetails.City.Should().Be(workshopDto.City);
        result.ContactDetails.PhoneNumber.Should().Be(workshopDto.PhoneNumber);
        result.ContactDetails.PostalCode.Should().Be(workshopDto.PostalCode);
        result.ContactDetails.Street.Should().Be(workshopDto.Street);
    }

    [Fact]
    public void MappingProfile_ShouldMapWorkshopToWorkshopDto_IsEditableTrueForUser()
    {
        // Arrange

        var userContextMock = new Mock<IUserContext>();
        userContextMock
            .Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new WorkshopMappingProfile(userContextMock.Object)));

        var mapper = configuration.CreateMapper();

        var workshop = new Workshop
        {
            Id = 1,
            CreateById = "1",
            ContactDetails = new WorkshopContactDetails
            {
                City = "City",
                PhoneNumber = "123456789",
                PostalCode = "12345",
                Street = "Street"
            }
        };

        // Act

        var result = mapper.Map<WorkshopDto>(workshop);

        // Assert

        result.Should().NotBeNull();
        result.IsEditable.Should().Be(true);
        result.City.Should().Be(workshop.ContactDetails.City);
        result.PhoneNumber.Should().Be(workshop.ContactDetails.PhoneNumber);
        result.PostalCode.Should().Be(workshop.ContactDetails.PostalCode);
        result.Street.Should().Be(workshop.ContactDetails.Street);
    }

    [Fact]
    public void MappingProfile_ShouldMapWorkshopToWorkshopDto_IsEditableFalseForUser()
    {
        // Arrange

        var userContextMock = new Mock<IUserContext>();
        userContextMock
            .Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@test.com", new[] { "User" }));

        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new WorkshopMappingProfile(userContextMock.Object)));

        var mapper = configuration.CreateMapper();

        var workshop = new Workshop
        {
            Id = 1,
            CreateById = "1",
            ContactDetails = new WorkshopContactDetails
            {
                City = "City",
                PhoneNumber = "123456789",
                PostalCode = "12345",
                Street = "Street"
            }
        };

        // Act

        var result = mapper.Map<WorkshopDto>(workshop);

        // Assert

        result.Should().NotBeNull();
        result.IsEditable.Should().Be(false);
        result.City.Should().Be(workshop.ContactDetails.City);
        result.PhoneNumber.Should().Be(workshop.ContactDetails.PhoneNumber);
        result.PostalCode.Should().Be(workshop.ContactDetails.PostalCode);
        result.Street.Should().Be(workshop.ContactDetails.Street);
    }

    [Fact]
    public void MappingProfile_ShouldMapWorkshopToWorkshopDto_IsEditableTrueForRedactor()
    {
        // Arrange

        var userContextMock = new Mock<IUserContext>();
        userContextMock
            .Setup(c => c.GetCurrentUser())
            .Returns(new CurrentUser("2", "test@test.com", new[] { "Redactor" }));

        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new WorkshopMappingProfile(userContextMock.Object)));

        var mapper = configuration.CreateMapper();

        var workshop = new Workshop
        {
            Id = 1,
            CreateById = "1",
            ContactDetails = new WorkshopContactDetails
            {
                City = "City",
                PhoneNumber = "123456789",
                PostalCode = "12345",
                Street = "Street"
            }
        };

        // Act

        var result = mapper.Map<WorkshopDto>(workshop);

        // Assert

        result.Should().NotBeNull();
        result.IsEditable.Should().Be(true);
        result.City.Should().Be(workshop.ContactDetails.City);
        result.PhoneNumber.Should().Be(workshop.ContactDetails.PhoneNumber);
        result.PostalCode.Should().Be(workshop.ContactDetails.PostalCode);
        result.Street.Should().Be(workshop.ContactDetails.Street);
    }
}