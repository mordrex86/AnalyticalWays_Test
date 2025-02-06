using Xunit;
using Moq;
using FluentAssertions;
using AcmeSchool.Core.Application.Services;
using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.Exceptions;

namespace AcmeSchool.Tests.Services;

public class EnrollStudentServiceTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly Mock<ICourseRepository> _courseRepositoryMock;
    private readonly Mock<IEnrollmentRepository> _enrollmentRepositoryMock;
    private readonly EnrollStudentService _enrollStudentService;

    public EnrollStudentServiceTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _courseRepositoryMock = new Mock<ICourseRepository>();
        _enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();

        _enrollStudentService = new EnrollStudentService(
            _studentRepositoryMock.Object,
            _courseRepositoryMock.Object,
            _enrollmentRepositoryMock.Object);
    }

    [Fact]
    public void EnrollStudent_Should_Create_Enrollment_When_Payment_Is_Made()
    {
        // Arrange
        var student = new Student("Alice", 20);
        var course = new Course("Physics", 200, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddMonths(1));

        _studentRepositoryMock.Setup(repo => repo.GetById(student.Id)).Returns(student);
        _courseRepositoryMock.Setup(repo => repo.GetById(course.Id)).Returns(course);

        // Act
        var enrollment = _enrollStudentService.Execute(student.Id, course.Id, true);

        // Assert
        enrollment.Should().NotBeNull();
        enrollment.Student.Should().Be(student);
        enrollment.Course.Should().Be(course);
        _enrollmentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Enrollment>()), Times.Once);
    }

    [Fact]
    public void EnrollStudent_Should_Throw_Exception_When_Payment_Is_Required_But_Not_Made()
    {
        // Arrange
        var student = new Student("Bob", 22);
        var course = new Course("Chemistry", 100, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddMonths(1));

        _studentRepositoryMock.Setup(repo => repo.GetById(student.Id)).Returns(student);
        _courseRepositoryMock.Setup(repo => repo.GetById(course.Id)).Returns(course);

        // Act
        Action act = () => _enrollStudentService.Execute(student.Id, course.Id, false);

        // Assert
        act.Should().Throw<InvalidEnrollmentException>()
            .WithMessage("Student must pay the registration fee to enroll.");
    }
}
