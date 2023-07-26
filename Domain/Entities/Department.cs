using Grupo3_Unapec.Domain.Common;
using System.Collections.ObjectModel;

namespace Grupo3_Unapec.Domain.Entities;

public class Department : BaseEntity
{
    public required string Name { get; init; }

    public ICollection<Area> Areas { get; set; } = new Collection<Area>();
}