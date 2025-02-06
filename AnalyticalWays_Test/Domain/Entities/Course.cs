namespace AcmeSchool.Core.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal RegistrationFee { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    private Course() { } // Constructor privado para futuras integraciones con EF Core

    public Course(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Course name cannot be empty.", nameof(name));

        if (registrationFee < 0)
            throw new ArgumentException("Registration fee cannot be negative.", nameof(registrationFee));

        if (startDate >= endDate)
            throw new ArgumentException("Start date must be before end date.");

        Id = Guid.NewGuid();
        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
    }
}
