namespace AcmeSchool.Core.Application.Interfaces;

using AcmeSchool.Core.Domain.Entities;

public interface IEnrollmentRepository
{
    void Add(Enrollment enrollment);
    IEnumerable<Enrollment> GetEnrollmentsByDateRange(DateTime startDate, DateTime endDate);
}
