using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Leader02.Application.Mappers;

namespace Leader02.Application.Services;

public class SubDepartmentService : ISubDepartmentService
{
    private readonly ISubDepartmentRepository _subDepartmentRepository;
    private readonly ISubDepartmentTsVectorRepository _subDepartmentTsVectorRepository;

    public SubDepartmentService(ISubDepartmentRepository subDepartmentRepository, ISubDepartmentTsVectorRepository subDepartmentTsVectorRepository)
    {
        _subDepartmentRepository = subDepartmentRepository;
        _subDepartmentTsVectorRepository = subDepartmentTsVectorRepository;
    }


    public async Task<SubDepartmentDto?> FindByNameOrDescription(string searchString, CancellationToken ct)
    {
        var subDepartmentTsVectors = await _subDepartmentTsVectorRepository.FindManyByName(searchString, ct);

        if (subDepartmentTsVectors.Count > 0)
        {
            var subDepartment = await _subDepartmentRepository.GetById(subDepartmentTsVectors[0].Id, ct);
            if (subDepartment != null) return subDepartment.SubDepartmentToSubDepartmentDto();
        }

        return null;
    }
}