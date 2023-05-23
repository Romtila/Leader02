using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class SubDepartmentRepository : BaseRepository<SubDepartment>, ISubDepartmentRepository
{
    public SubDepartmentRepository(Leader02Context dbContext) : base(dbContext)
    {
    }
}