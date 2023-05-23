using Leader.Domain.Entity;

namespace Leader.Domain.Interfaces;

public interface IRequirementRepository : IBaseRepository<Requirement>
{
    Task<List<Requirement>> FindBySubDepartment(int id, CancellationToken ct);
    Task<List<Requirement>> FindByDepartment(int id, CancellationToken ct);
    Task<List<Requirement>> FindByBasicRequirementDescription(string basicRequirementDescription, CancellationToken ct);
    Task<List<Requirement>> FindByBasicRequirementDetail(string basicRequirementDetail, CancellationToken ct);
}