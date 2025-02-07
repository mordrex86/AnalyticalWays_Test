namespace AcmeSchool.Core.Application.Services;

using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.Exceptions;

public class EnrollStudentUseCase
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollStudentUseCase(
        IStudentRepository studentRepository,
        ICourseRepository courseRepository,
        IEnrollmentRepository enrollmentRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public Enrollment Execute(Guid studentId, Guid courseId, bool hasPaid)
    {
        var student = _studentRepository.GetById(studentId)
            ?? throw new DomainException("Student not found.");

        var course = _courseRepository.GetById(courseId)
            ?? throw new DomainException("Course not found.");

        if (!hasPaid && course.RegistrationFee.Amount > 0) // Acceder a la propiedad Amount
            throw new InvalidEnrollmentException("Student must pay the registration fee to enroll.");

        var enrollment = new Enrollment(student, course, hasPaid);
        _enrollmentRepository.Add(enrollment);

        return enrollment;
    }
}
