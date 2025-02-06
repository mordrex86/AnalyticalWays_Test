namespace AcmeSchool.Core.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; } //Se encapsulan las propiedades (private set) para garantizar la inmutabilidad. DDD
    public string Name { get; private set; } = string.Empty;
    public int Age { get; private set; }

    private Student() { } // Constructor privado para EF Core (futuro)

    public Student(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("The student's name cannot be empty.", nameof(name));

        if (age < 18)
            throw new ArgumentException("Only adults (18+) can register.", nameof(age));

        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }
}
