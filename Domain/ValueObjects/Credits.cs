using Grupo3_Unapec.Domain.Common;

namespace Grupo3_Unapec.Domain.ValueObjects;

public class Credits : ValueObject
{
    public float Theoretical { get; init; }

    public float Laboratory { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Theoretical;
        yield return Laboratory;
    }
}