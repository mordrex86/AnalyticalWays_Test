using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Application.Services;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.ValueObjects;
using FluentAssertions;
using Moq;

namespace AcmeSchool.Tests.Services;

public class RegisterStudentUseCaseTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly RegisterStudentUseCase _registerStudentService;

    public RegisterStudentUseCaseTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _registerStudentService = new RegisterStudentUseCase(_studentRepositoryMock.Object);
    }

    [Fact]
    public void RegisterStudent_Should_Create_Valid_Student()
    {
        // Arrange
        var studentName = new StudentName("John Doe");
        var age = 20;

        // Act
        var student = _registerStudentService.Execute(studentName.Value, age);

        // Assert
        student.Should().NotBeNull();
        student.Name.Should().Be(studentName);
        student.Age.Should().Be(age);
        _studentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Student>()), Times.Once);
    }
}
