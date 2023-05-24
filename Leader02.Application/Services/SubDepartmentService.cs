using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;

namespace Leader02.Application.Services;

public class SubDepartmentService : ISubDepartmentService
{
    private readonly ISubDepartmentRepository _subDepartmentRepository;

    public SubDepartmentService(ISubDepartmentRepository subDepartmentRepository)
    {
        _subDepartmentRepository = subDepartmentRepository;
    }


    public Task<SubDepartmentDto> FindByNameOrDescription(string searchString, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}