using Grupo3_Unapec.Application.Common.Interfaces;
using Grupo3_Unapec.Domain.Entities;
using Grupo3_Unapec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Grupo3_Unapec.Infrastructure.Persistence.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Teacher?> GetWithAllInformationAsync(int id, CancellationToken cancellationToken = default) =>
        await EntityCollection
        .Include(teacher => teacher.Area)
            .ThenInclude(area => area!.Department)
        .Include(teacher => teacher.Subjects)
        .FirstOrDefaultAsync(teacher => teacher.Id == id, cancellationToken);
}