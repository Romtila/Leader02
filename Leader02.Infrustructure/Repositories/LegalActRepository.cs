using Leader.Domain.Entity;
using Leader.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leader02.Infrastructure.Repositories;

public class LegalActRepository : BaseRepository<LegalAct>, ILegalActRepository
{
    public LegalActRepository(Leader02Context dbContext) : base(dbContext)
    {
    }

    public async Task<LegalAct?> GetById(int id, CancellationToken ct)
    {
        return await DbContext.LegalActs.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }

    public Task<List<LegalAct>> FindBySubDepartmentId(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<LegalAct>> FindByDepartmentId(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<LegalAct>> FindManyByName(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}