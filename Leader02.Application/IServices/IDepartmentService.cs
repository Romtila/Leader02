using Leader02.Application.DtoModels;

namespace Leader02.Application.IServices;

public interface IDepartmentService
{
    Task<DepartmentDto> FindByAbbreviationOrNameOrDescription(string searchString, CancellationToken ct);
}