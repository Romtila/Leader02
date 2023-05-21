namespace Leader.Domain.Entity;

public class LowAct
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LowActType { get; set; } = string.Empty;
    public DateTime DocumentDate { get; set; }
    public DateTime PublishDate { get; set; }
    public string? LowActUrl { get; set; }
    
    public Department? Department { get; set; } = new();
    public SubDepartment? SubDepartment { get; set; } = new();
}