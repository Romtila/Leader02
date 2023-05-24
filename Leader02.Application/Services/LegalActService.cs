using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;

namespace Leader02.Application.Services;

public class LegalActService : ILegalActService
{
    private readonly ILegalActRepository _legalActRepository;

    public LegalActService(ILegalActRepository legalActRepository)
    {
        _legalActRepository = legalActRepository;
    }

    public Task<List<LegalActDto>> FindBySubDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<LegalActDto>> FindByDepartment(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<LegalActDto> FindByName(string name, CancellationToken ct)
    {
        if (name.ToLower().Contains("нпа") ||
            (name.ToLower().Contains("прав") && name.ToLower().Contains("акт")) ||
            (name.ToLower().Contains("норм") && name.ToLower().Contains("права")) ||
            name.ToLower().Contains("закон"))
        {
        }

        throw new NotImplementedException();
    }
}