using Grupo3_Unapec.Domain.Common;
using System.Collections.ObjectModel;

namespace Grupo3_Unapec.Domain.Entities;

public class Area : BaseEntity
{
    public required string Name { get; init; }

    public required int DepartmentId { get; init; }

    public Department? Department { get; init; }

    public ICollection<Teacher> Teachers { get; init; } = new Collection<Teacher>();

    public ICollection<Subject> Subjects { get; init; } = new Collection<Subject>();
}