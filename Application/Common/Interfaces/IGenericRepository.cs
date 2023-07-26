using Grupo3_Unapec.Domain.Common;

namespace Grupo3_Unapec.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);

    Task<T?> UpdateAsync(T newEntity, CancellationToken cancellationToken = default);

    Task<T?> RemoveAsync(int id, CancellationToken cancellationToken = default);
}