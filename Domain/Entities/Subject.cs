using Grupo3_Unapec.Domain.Common;
using Grupo3_Unapec.Domain.ValueObjects;
using System.Collections.ObjectModel;

namespace Grupo3_Unapec.Domain.Entities;

public class Subject : BaseEntity
{
    public required string Name { get; init; }

    public required SubjectCode Code { get; init; }

    public required string Type { get; init; }

    public int Course { get; init; }

    public required Credits Credits { get; init; }

    public required string Duration { get; init; }

    public required int AreaId { get; init; }

    public Area? Area { get; init; }

    public int TitleId { get; init; }

    public Title? Title { get; init; }

    public int? TitleConfigurationId { get; init; }

    public Title? TitleConfiguration { get; init; }

    public ICollection<Teacher> Teachers { get; init; } = new Collection<Teacher>();

    public ICollection<Subject> IncompatiblesSubjects { get; init; } = new Collection<Subject>();

    public ICollection<Subject> RequiredForSubjects { get; init; } = new Collection<Subject>();

    public ICollection<Subject> PreRequiredSubjects { get; init; } = new Collection<Subject>();

    public ICollection<Subject> EquivalentSubjects { get; init; } = new Collection<Subject>();
}