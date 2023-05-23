using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class DepartmentUserRepository : BaseRepository<DepartmentUser>, IDepartmentUserRepository
{
    public DepartmentUserRepository(Leader02Context dbContext) : base(dbContext)
    {
    }

    public Task<DepartmentUser> FindByEmail(string email, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<DepartmentUser> FindByMobilePhone(string mobilePhone, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}