namespace AcmeSchool.Core.Application.Services;

using AcmeSchool.Core.Application.Interfaces;
using AcmeSchool.Core.Domain.Entities;
using AcmeSchool.Core.Domain.ValueObjects;

public class RegisterStudentUseCase
{
    private readonly IStudentRepository _studentRepository;

    public RegisterStudentUseCase(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Student Execute(string name, int age)
    {
        var studentName = new StudentName(name); // Crear el objeto de valor
        var student = new Student(studentName, age);
        _studentRepository.Add(student);
        return student;
    }

}
