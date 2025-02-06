namespace AcmeSchool.Core.Domain.ValueObjects;

public sealed class StudentName
{
    public string Value { get; }

    public StudentName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Student name cannot be empty.", nameof(value));

        Value = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not StudentName other) return false;
        return Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}
