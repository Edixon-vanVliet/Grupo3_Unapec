using Grupo3_Unapec.Domain.Entities;

namespace Grupo3_Unapec.Application.Common.Interfaces;

public interface ISubjectRepository : IGenericRepository<Subject>
{
    Task<Subject?> GetWithAllInformationAsync(int id, CancellationToken cancellationToken = default);
}