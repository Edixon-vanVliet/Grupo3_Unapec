using Grupo3_Unapec.Application.Common.Interfaces;
using Grupo3_Unapec.Domain.Common;
using Grupo3_Unapec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Grupo3_Unapec.Infrastructure.Persistence.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    protected DbSet<T> EntityCollection => _context.Set<T>();

    protected GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await EntityCollection.AddAsync(entity, cancellationToken);
    }

    public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await EntityCollection.ToListAsync(cancellationToken);

    public async Task<T?> GetAsync(int id, CancellationToken cancellationToken = default) =>
        await EntityCollection.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public async Task<T?> UpdateAsync(T newEntity, CancellationToken cancellationToken = default)
    {
        var entity = await GetAsync(newEntity.Id, cancellationToken);

        if (entity is not null)
        {
            EntityCollection.Update(newEntity);

            return newEntity;
        }

        return entity;
    }

    public async Task<T?> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetAsync(id, cancellationToken);

        if (entity is not null)
        {
            EntityCollection.Remove(entity);
        }

        return entity;
    }
}