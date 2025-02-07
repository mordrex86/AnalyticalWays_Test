namespace AcmeSchool.Core.Domain.Entities;

public class Enrollment
{
    public Guid Id { get; private set; }
    public Student Student { get; private set; } = null!;
    public Course Course { get; private set; } = null!;
    public DateTime EnrollmentDate { get; private set; }
    public bool HasPaid { get; private set; }

    private Enrollment() { }

    public Enrollment(Student student, Course course, bool hasPaid)
    {
        Student = student ?? throw new ArgumentNullException(nameof(student));
        Course = course ?? throw new ArgumentNullException(nameof(course));
        HasPaid = hasPaid;
        EnrollmentDate = DateTime.UtcNow;
        Id = Guid.NewGuid();
    }
}
