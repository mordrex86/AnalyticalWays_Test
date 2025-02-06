namespace AcmeSchool.Core.Domain.Exceptions;

public class InvalidEnrollmentException : DomainException
{
    public InvalidEnrollmentException(string message) : base(message) { }
}
