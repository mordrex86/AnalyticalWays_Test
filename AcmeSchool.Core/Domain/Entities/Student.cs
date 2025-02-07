namespace AcmeSchool.Core.Domain.Entities;

using AcmeSchool.Core.Domain.ValueObjects;

public class Student
{
    public Guid Id { get; private set; }
    public StudentName Name { get; private set; } = null!;
    public int Age { get; private set; }

    private Student() { }

    public Student(StudentName name, int age)
    {
        if (age < 18)
            throw new ArgumentException("Only adults (18+) can register.", nameof(age));

        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }
}

