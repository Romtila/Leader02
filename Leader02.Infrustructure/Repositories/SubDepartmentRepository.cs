using Leader.Domain.Entity;
using Leader.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leader02.Infrastructure.Repositories;

public class SubDepartmentRepository : BaseRepository<SubDepartment>, ISubDepartmentRepository
{
    public SubDepartmentRepository(Leader02Context dbContext) : base(dbContext)
    {
    }

    public async Task<SubDepartment?> GetById(int id, CancellationToken ct)
    {
        return await DbContext.SubDepartments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }

    public Task<List<SubDepartment>> GetByDepartmentId(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<(int, string)>> GetAllName(string name, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<(int, string)>> GetAllDescription(string description, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}