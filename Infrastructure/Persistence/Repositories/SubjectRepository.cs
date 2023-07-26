using Grupo3_Unapec.Application.Common.Interfaces;
using Grupo3_Unapec.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grupo3_Unapec.Infrastructure.Persistence.Repositories;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Subject?> GetWithAllInformationAsync(int id, CancellationToken cancellationToken = default) =>
        await EntityCollection
        .Include(subject => subject.Area)
            .ThenInclude(area => area!.Department)
        .Include(subject => subject.Title)
        .Include(subject => subject.TitleConfiguration)
        .Include(subject => subject.EquivalentSubjects)
        .Include(subject => subject.IncompatiblesSubjects)
        .Include(subject => subject.Teachers)
        .FirstOrDefaultAsync(subject => subject.Id == id, cancellationToken);
}