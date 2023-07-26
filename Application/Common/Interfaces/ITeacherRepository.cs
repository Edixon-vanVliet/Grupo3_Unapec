using Grupo3_Unapec.Domain.Entities;

namespace Grupo3_Unapec.Application.Common.Interfaces;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<Teacher?> GetWithAllInformationAsync(int id, CancellationToken cancellationToken = default);
}