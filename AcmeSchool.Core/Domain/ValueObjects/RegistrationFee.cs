namespace AcmeSchool.Core.Domain.ValueObjects;

public sealed class RegistrationFee
{
    public decimal Amount { get; } 

    public RegistrationFee(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Registration fee cannot be negative.", nameof(amount));

        Amount = amount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not RegistrationFee other) return false;
        return Amount == other.Amount;
    }

    public override int GetHashCode() => Amount.GetHashCode();

    public override string ToString() => $"{Amount:C}";
}
