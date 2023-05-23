using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class RequirementRepository : BaseRepository<Requirement>, IRequirementRepository
{
    public RequirementRepository(Leader02Context dbContext) : base(dbContext)
    {
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