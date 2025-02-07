namespace AcmeSchool.Core.Application.Interfaces;

using AcmeSchool.Core.Domain.Entities;

public interface ICourseRepository
{
    void Add(Course course);
    Course? GetById(Guid id);
}
