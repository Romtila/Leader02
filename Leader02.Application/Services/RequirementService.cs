using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;

namespace Leader02.Application.Services;

public class RequirementService : IRequirementService
{
    private readonly IRequirementRepository _requirementRepository;

    public RequirementService(IRequirementRepository requirementRepository)
    {
        _requirementRepository = requirementRepository;
    }

    public Task<List<RequirementDto>> FindManyBySubDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<RequirementDto>> FindManyByDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<RequirementDto> FindByBasicRequirementDescriptionAndDetail(string searchString, CancellationToken ct)
    {
        if (searchString.ToLower().Contains("обяза") ||
            searchString.ToLower().Contains("треб") ||
            searchString.ToLower().Contains("нужн"))
        {
        }

        throw new NotImplementedException();
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