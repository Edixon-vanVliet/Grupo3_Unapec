using Grupo3_Unapec.Domain.Common;

namespace Grupo3_Unapec.Domain.ValueObjects;

public class Schedule : ValueObject
{
    public required string Day { get; init; }

    public required TimeOnly FromTime { get; init; }

    public required TimeOnly ToTime { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Day;
        yield return FromTime;
        yield return ToTime;
    }
}