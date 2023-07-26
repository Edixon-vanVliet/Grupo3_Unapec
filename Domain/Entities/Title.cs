using Grupo3_Unapec.Domain.Common;
using System.Collections.ObjectModel;

namespace Grupo3_Unapec.Domain.Entities;

public class Title : BaseEntity
{
    public required string Name { get; init; }

    public ICollection<Subject> Subjects { get; init; } = new Collection<Subject>();

    public ICollection<Subject> ConfigurationSubjects { get; init; } = new Collection<Subject>();
}