using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Application.Services;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.Exceptions;
using AcmeSchool.Core.Domain.ValueObjects;
using FluentAssertions;
using Moq;

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
        var studentName = new StudentName("Alice");
        var student = new Student(studentName, 20);

        var registrationFee = new RegistrationFee(200);
        var course = new Course("Physics", registrationFee, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddMonths(1));

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
        var studentName = new StudentName("Bob");
        var student = new Student(studentName, 22);

        var registrationFee = new RegistrationFee(100);
        var course = new Course("Chemistry", registrationFee, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddMonths(1));

        _studentRepositoryMock.Setup(repo => repo.GetById(student.Id)).Returns(student);
        _courseRepositoryMock.Setup(repo => repo.GetById(course.Id)).Returns(course);

        // Act
        Action act = () => _enrollStudentService.Execute(student.Id, course.Id, false);

        // Assert
        act.Should().Throw<InvalidEnrollmentException>()
           .WithMessage("Student must pay the registration fee to enroll.");
    }
}
