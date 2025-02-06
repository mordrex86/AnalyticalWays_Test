using Xunit;
using FluentAssertions;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.ValueObjects;

namespace AcmeSchool.Tests.Domain.Entities;

public class StudentTests
{
    [Fact]
    public void Student_Should_Be_Created_With_Valid_Data()
    {
        // Arrange
        var name = new StudentName("John Doe");

        // Act
        var student = new Student(name, 20);

        // Assert
        student.Name.Should().Be(name);
        student.Age.Should().Be(20);
    }

    [Fact]
    public void Student_Should_Throw_Exception_For_Invalid_Age()
    {
        // Arrange
        var name = new StudentName("John Doe");

        // Act
        Action act = () => new Student(name, 17);

        // Assert
        act.Should().Throw<ArgumentException>()
           .WithMessage("Only adults (18+) can register. (Parameter 'age')");
    }
}
