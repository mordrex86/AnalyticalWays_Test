namespace AcmeSchool.Core.Application.Services;

using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;

public class RegisterStudentService
{
    private readonly IStudentRepository _studentRepository;

    public RegisterStudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Student Execute(string name, int age)
    {
        var student = new Student(name, age);
        _studentRepository.Add(student);
        return student;
    }
}
