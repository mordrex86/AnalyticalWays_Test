namespace AcmeSchool.Core.Domain.Entities;

using AcmeSchool.Core.Domain.ValueObjects;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public RegistrationFee RegistrationFee { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    private Course() { }

    public Course(string name, RegistrationFee registrationFee, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Course name cannot be empty.", nameof(name));

        if (startDate >= endDate)
            throw new ArgumentException("Start date must be before end date.");

        Id = Guid.NewGuid();
        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
    }
}
