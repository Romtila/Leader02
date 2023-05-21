namespace Leader.Domain.Entity;

public class SubDepartment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? SubDepartmentUrl { get; set; }
    public string? SubDepartmentDescription { get; set; }
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = new();
    
    public List<DepartmentUser>? DepartmentUsers { get; set; } = new();
    public List<ConsultationSlot>? ConsultationSlots { get; set; } = new();
    public List<ConsultationTopic>? ConsultationTopics { get; set; } = new();
}