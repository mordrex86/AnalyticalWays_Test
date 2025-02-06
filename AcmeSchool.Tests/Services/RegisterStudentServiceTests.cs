using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Application.Services;
using AcmeSchool.Core.Domain.Entities;
using FluentAssertions;
using Moq;

namespace AcmeSchool.Tests.Services;

public class RegisterStudentServiceTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly RegisterStudentService _registerStudentService;

    public RegisterStudentServiceTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _registerStudentService = new RegisterStudentService(_studentRepositoryMock.Object);
    }

    [Fact]
    public void RegisterStudent_Should_Create_Valid_Student()
    {
        // Arrange
        var name = "John Doe";
        var age = 20;

        // Act
        var student = _registerStudentService.Execute(name, age);

        // Assert
        student.Should().NotBeNull();
        student.Name.Should().Be(name);
        student.Age.Should().Be(age);
        _studentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Student>()), Times.Once);
    }

    [Theory]
    [InlineData("", 20)]
    [InlineData("John Doe", 17)]
    public void RegisterStudent_Should_Throw_Exception_When_Invalid_Data(string name, int age)
    {
        // Act
        Action act = () => _registerStudentService.Execute(name, age);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
