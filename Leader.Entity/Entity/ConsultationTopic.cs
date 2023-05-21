namespace Leader.Domain.Entity;

public class ConsultationTopic
{
    public int Id { get; set; }
    public string Topic { get; set; } = string.Empty;

    public int SubDepartmentId { get; set; }
    public SubDepartment SubDepartment { get; set; } = new();
}