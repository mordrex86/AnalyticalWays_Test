namespace AcmeSchool.Core.Application.Interfaces;

using AcmeSchool.Core.Domain.Entities;

public interface IStudentRepository
{
    void Add(Student student);
    Student? GetById(Guid id);
}
