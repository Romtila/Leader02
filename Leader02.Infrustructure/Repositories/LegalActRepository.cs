using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class LegalActRepository : BaseRepository<LegalAct>, ILegalActRepository
{
    public LegalActRepository(Leader02Context dbContext) : base(dbContext)
    {
    }

    public Task<List<LegalAct>> FindBySubDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<LegalAct>> FindByDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<LegalAct>> FindByName(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}