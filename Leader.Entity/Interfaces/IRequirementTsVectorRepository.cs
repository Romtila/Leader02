using Leader.Domain.Entity;

namespace Leader.Domain.Interfaces;

public interface IRequirementTsVectorRepository : IBaseRepository<RequirementTsVector>
{
    Task<RequirementTsVector?> FindByBasicRequirementDetail(string basicRequirementDetail, CancellationToken ct);
    Task<List<RequirementTsVector>> FindManyByBasicRequirementDetail(string basicRequirementDetail, CancellationToken ct);
}