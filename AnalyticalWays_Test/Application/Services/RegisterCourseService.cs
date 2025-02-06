namespace AcmeSchool.Core.Application.Services;

using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;

public class RegisterCourseService
{
    private readonly ICourseRepository _courseRepository;

    public RegisterCourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Course Execute(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
    {
        var course = new Course(name, registrationFee, startDate, endDate);
        _courseRepository.Add(course);
        return course;
    }
}
