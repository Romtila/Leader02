using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Leader02.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IServiceScopeFactory serviceScopeFactory)
    {
        _departmentRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IDepartmentRepository>();
    }


    public Task<DepartmentDto> FindByAbbreviationOrNameOrDescription(string searchString, CancellationToken ct)
    {
        if ((searchString.ToLower().Contains("орган") && searchString.ToLower().Contains("власт")) ||
                                     searchString.ToLower().Contains("какой департамент"))
        {
            
        }
        throw new NotImplementedException();
    }
}