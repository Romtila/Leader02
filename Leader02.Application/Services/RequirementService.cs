using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Leader02.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Leader02.Application.Services;

public class RequirementService : IRequirementService
{
    private readonly IRequirementRepository _requirementRepository;
    private readonly IRequirementTsVectorRepository _requirementTsVectorRepository;

    public RequirementService(IServiceScopeFactory serviceScopeFactory)
    {
        _requirementRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRequirementRepository>();
        _requirementTsVectorRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRequirementTsVectorRepository>();
    }

    public Task<List<RequirementDto>> FindManyBySubDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<RequirementDto>> FindManyByDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<RequirementDto?> FindByBasicRequirement(string searchString, CancellationToken ct)
    {
        var requirementTsVectors = await _requirementTsVectorRepository.FindManyByBasicRequirementDetail(searchString, ct);

        if (requirementTsVectors.Count > 0)
        {
            requirementTsVectors = requirementTsVectors.Where(x => x.Number == requirementTsVectors[0].Number).ToList();

            var requirementIds = requirementTsVectors.Select(x => x.Id).ToArray();

            var requirements = await _requirementRepository.GetManyByIds(requirementIds, ct);

            var requirementFull = new RequirementFullDto();
            //заполняем requirementFull
        }

        return null;
    }

    public async Task<List<RequirementDto>?> FindManyByBasicRequirement(string searchString, CancellationToken ct)
    {
        var requirementTsVectors = await _requirementTsVectorRepository.FindManyByBasicRequirementDetail(searchString, ct);

        var requirementIds = requirementTsVectors.Select(x => x.Id).ToArray();

        var requirements = await _requirementRepository.GetManyByIds(requirementIds, ct);

        if (requirements.Count > 0)
        {
            return requirements.RequirementToRequirementDto();
        }

        return null;
    }

    public Task<RequirementDto> FindByBasicRequirementDescription(string basicRequirementDescription, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<RequirementDto> FindByBasicRequirementDetail(string basicRequirementDetail, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}