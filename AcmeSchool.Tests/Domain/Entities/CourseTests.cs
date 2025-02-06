using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.ValueObjects;
using FluentAssertions;

namespace AcmeSchool.Tests.Domain.Entities;

public class CourseTests
{
    [Fact]
    public void Course_Should_Be_Created_With_Valid_Data()
    {
        // Arrange
        var registrationFee = new RegistrationFee(100);

        // Act
        var course = new Course("Mathematics", registrationFee, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddMonths(1));

        // Assert
        course.Name.Should().Be("Mathematics");
        course.RegistrationFee.Should().Be(registrationFee);
    }

    [Fact]
    public void Course_Should_Throw_Exception_For_Invalid_Dates()
    {
        // Arrange
        var registrationFee = new RegistrationFee(100);
        var startDate = DateTime.UtcNow.AddMonths(1);
        var endDate = DateTime.UtcNow;

        // Act
        Action act = () => new Course("Math", registrationFee, startDate, endDate);

        // Assert
        act.Should().Throw<ArgumentException>()
           .WithMessage("Start date must be before end date.");
    }
}
