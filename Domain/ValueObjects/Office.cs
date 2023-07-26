using Grupo3_Unapec.Domain.Common;

namespace Grupo3_Unapec.Domain.ValueObjects;

public class Office : ValueObject
{
    public required string Code { get; init; }

    public required int Number { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Number;
    }

    public override string ToString() =>
        $"{Code}{Number}";
}