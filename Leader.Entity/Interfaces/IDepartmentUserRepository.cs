using Leader.Domain.Entity;

namespace Leader.Domain.Interfaces;

public interface IDepartmentUserRepository : IBaseRepository<DepartmentUser>
{
    Task<DepartmentUser> FindByEmail(string email, CancellationToken ct);
    Task<DepartmentUser> FindByMobilePhone(string mobilePhone, CancellationToken ct);
}