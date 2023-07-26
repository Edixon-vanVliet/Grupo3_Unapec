using Grupo3_Unapec.Domain.Common;
using Grupo3_Unapec.Domain.ValueObjects;
using System.Collections.ObjectModel;

namespace Grupo3_Unapec.Domain.Entities;

public class Teacher : BaseEntity
{
    public required Name Name { get; init; }

    public Office? Office { get; init; }

    public int AreaId { get; init; }

    public Area? Area { get; set; }

    public required ICollection<Schedule> Schedules { get; init; } = new Collection<Schedule>();

    public ICollection<Subject> Subjects { get; init; } = new Collection<Subject>();
}