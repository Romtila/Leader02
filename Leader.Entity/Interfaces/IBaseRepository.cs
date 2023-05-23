namespace Leader.Domain.Interfaces;

public interface IBaseRepository<in T> where T : class
{
    Task AddAsync(T entity, CancellationToken ct);
    Task AddManyAsync(IEnumerable<T> entity, CancellationToken ct);
    Task UpdateAsync(T entity, CancellationToken ct);
    Task RemoveAsync(T entity, CancellationToken ct);
}