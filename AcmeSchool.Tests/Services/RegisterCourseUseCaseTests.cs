using Xunit;
using Moq;
using FluentAssertions;
using AcmeSchool.Core.Application.Services;
using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.ValueObjects;

namespace AcmeSchool.Tests.Services;

public class RegisterCourseUseCaseTests
{
    private readonly Mock<ICourseRepository> _courseRepositoryMock;
    private readonly RegisterCourseUseCase _registerCourseService;

    public RegisterCourseUseCaseTests()
    {
        _courseRepositoryMock = new Mock<ICourseRepository>();
        _registerCourseService = new RegisterCourseUseCase(_courseRepositoryMock.Object);
    }

    [Fact]
    public void RegisterCourse_Should_Create_Valid_Course()
    {
        // Arrange
        var name = "Mathematics";
        var registrationFee = new RegistrationFee(100); // Usar el ValueObject
        var startDate = DateTime.UtcNow.AddDays(1);
        var endDate = DateTime.UtcNow.AddMonths(1);

        // Act
        var course = _registerCourseService.Execute(name, registrationFee.Amount, startDate, endDate);

        // Assert
        course.Should().NotBeNull();
        course.Name.Should().Be(name);
        course.RegistrationFee.Should().Be(registrationFee);
        _courseRepositoryMock.Verify(repo => repo.Add(It.IsAny<Course>()), Times.Once);
    }

    [Theory]
    [InlineData("", 100, "2025-01-01", "2025-02-01")] // Nombre vacío
    [InlineData("Math", -50, "2025-01-01", "2025-02-01")] // Precio negativo
    [InlineData("Math", 100, "2025-02-01", "2025-01-01")] // Fechas incorrectas
    public void RegisterCourse_Should_Throw_Exception_When_Invalid_Data(string name, decimal fee, string start, string end)
    {
        // Arrange
        var startDate = DateTime.Parse(start);
        var endDate = DateTime.Parse(end);

        // Act
        Action act = () => _registerCourseService.Execute(name, fee, startDate, endDate);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
