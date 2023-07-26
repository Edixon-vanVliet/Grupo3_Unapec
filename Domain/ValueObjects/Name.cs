using Grupo3_Unapec.Domain.Common;

namespace Grupo3_Unapec.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }

    public override string ToString() =>
        $"{FirstName} {LastName}";
}