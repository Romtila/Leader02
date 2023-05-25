using Leader.Domain.Entity.RequirementsModels;
using Leader.Domain.Enums.Requirement;

namespace Leader.Domain.Entity;

public class Requirement
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string? BasicRequirementDescription { get; set; } // Описание базового требования (группы ОТ)	
    public string? BasicRequirementDetail { get; set; } // Детализация базового требования	
    public RequirementType? RequirementType { get; set; } // Тип требования (1-к субъекту, 0-к объекту)	
    public string? RequirementNpasJson { get; set; } // json с моуделями RequirementNpa
    public string? RequirementProfilingJson { get; set; } // json модели RequirementProfiling
    public string? RequirementVerificationMethodsJson { get; set; } // json модели RequirementVerificationMethod
    public string? RequirementResponsibilitiesJson { get; set; } // json модели RequirementResponsibility

    public RequirementTsVector? RequirementBasicRequirement { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public int? SubDepartmentId { get; set; }
    public SubDepartment? SubDepartment { get; set; }
}