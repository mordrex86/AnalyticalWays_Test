using AcmeSchool.Core.Domain.ValueObjects;
using FluentAssertions;

namespace AcmeSchool.Tests.Domain.ValueObjects;

public class RegistrationFeeTests
{
    [Fact]
    public void Should_Create_Valid_RegistrationFee()
    {
        // Arrange & Act
        var fee = new RegistrationFee(150);

        // Assert
        fee.Amount.Should().Be(150);
    }

    [Fact]
    public void Should_Throw_Exception_When_Creating_Negative_RegistrationFee()
    {
        // Act
        Action act = () => new RegistrationFee(-50);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Registration fee cannot be negative.*");
    }

    [Fact]
    public void RegistrationFees_With_Same_Amount_Should_Be_Equal()
    {
        // Arrange
        var fee1 = new RegistrationFee(200);
        var fee2 = new RegistrationFee(200);

        // Assert
        fee1.Should().Be(fee2);
        fee1.GetHashCode().Should().Be(fee2.GetHashCode());
    }
}
