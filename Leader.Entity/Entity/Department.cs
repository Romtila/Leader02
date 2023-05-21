namespace Leader.Domain.Entity;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string? DepartmentUrl { get; set; }
    public string? Description { get; set; }

    public List<SubDepartment> SubDepartments { get; set; } = new();
    public List<ChatBotRequest> ChatBotRequests { get; set; } = new();
}