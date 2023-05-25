namespace Leader.Domain.Entity.RequirementsModels;

public class SanctionInfo
{
    /// <summary>
    /// Субъект ответственности
    /// </summary>
    public string? SubjectOfResponsibility { get; set; }	
    
    /// <summary>
    /// json модели SanctionAndSizeOfSanction
    /// </summary>
    public string? SanctionAndSizeOfSanctionJson { get; set; }
}