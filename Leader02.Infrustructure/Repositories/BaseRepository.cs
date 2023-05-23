using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly Leader02Context DbContext;

    protected BaseRepository(Leader02Context dbContext)
    {
        DbContext = dbContext;
    }

    public async Task AddAsync(T entity, CancellationToken ct)
    {
        await DbContext.Set<T>().AddAsync(entity, ct);
        await DbContext.SaveChangesAsync(ct);
    }

    public async Task AddManyAsync(IEnumerable<T> entity, CancellationToken ct)
    {
        await DbContext.Set<T>().AddRangeAsync(entity, ct);
        await DbContext.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(T entity, CancellationToken ct)
    {
        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(T entity, CancellationToken ct)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync(ct);
    }
}