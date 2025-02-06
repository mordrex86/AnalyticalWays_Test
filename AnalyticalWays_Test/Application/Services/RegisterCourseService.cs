namespace AcmeSchool.Core.Application.Services;

using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.ValueObjects;

public class RegisterCourseService
{
    private readonly ICourseRepository _courseRepository;

    public RegisterCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Course Execute(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
    {
        var fee = new RegistrationFee(registrationFee);
        var course = new Course(name, fee, startDate, endDate);
        _courseRepository.Add(course);
        return course;
    }

}
