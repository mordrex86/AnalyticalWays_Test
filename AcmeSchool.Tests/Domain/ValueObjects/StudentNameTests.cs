using AcmeSchool.Core.Domain.ValueObjects;
using FluentAssertions;

namespace AcmeSchool.Tests.Domain.ValueObjects;

public class StudentNameTests
{
    [Fact]
    public void Should_Create_Valid_StudentName()
    {
        // Arrange & Act
        var studentName = new StudentName("John Doe");

        // Assert
        studentName.Value.Should().Be("John Doe");
    }

    [Fact]
    public void Should_Throw_Exception_When_Creating_StudentName_With_Empty_Value()
    {
        // Act
        Action act = () => new StudentName("");

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Student name cannot be empty.*");
    }

    [Fact]
    public void Should_Throw_Exception_When_Creating_StudentName_With_Only_Spaces()
    {
        // Act
        Action act = () => new StudentName("   ");

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Student name cannot be empty.*");
    }

    [Fact]
    public void StudentNames_With_Same_Value_Should_Be_Equal()
    {
        // Arrange
        var name1 = new StudentName("Alice");
        var name2 = new StudentName("Alice");

        // Assert
        name1.Should().Be(name2);
        name1.GetHashCode().Should().Be(name2.GetHashCode());
    }
}
