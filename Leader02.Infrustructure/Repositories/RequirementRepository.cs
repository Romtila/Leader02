using Leader.Domain.Entity;
using Leader.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leader02.Infrastructure.Repositories;

public class RequirementRepository : BaseRepository<Requirement>, IRequirementRepository
{
    public RequirementRepository(Leader02Context dbContext) : base(dbContext)
    {
    }

    public async Task<Requirement?> GetById(long id, CancellationToken ct)
    {
        return await DbContext.Requirements.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }

    public async Task<List<Requirement>> GetManyByIds(IEnumerable<long> ids, CancellationToken ct)
    {
        return await DbContext.Requirements
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(cancellationToken: ct);
    }

    public Task<List<Requirement>> FindBySubDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<Requirement>> FindByDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<Requirement>> FindByBasicRequirementDescription(string basicRequirementDescription, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<Requirement>> FindByBasicRequirementDetail(string basicRequirementDetail, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}