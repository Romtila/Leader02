using Leader.Domain.Entity;

namespace Leader.Domain.Interfaces;

public interface ILegalActRepository : IBaseRepository<LegalAct>
{
    Task<List<LegalAct>> FindBySubDepartment(int id, CancellationToken ct);
    Task<List<LegalAct>> FindByDepartment(int id, CancellationToken ct);
    Task<List<LegalAct>> FindByName(int id, CancellationToken ct);
}