namespace Leader02.Application.DtoModels;

public class LowActDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? DepartmentNameId { get; set; }
    public string? DepartmentName { get; set; }
    public int? SubDepartmentId { get; set; }
    public string? SubDepartment { get; set; }
    public string LowActType { get; set; } = string.Empty;
    public DateTime DocumentDate { get; set; }
    public DateTime PublishDate { get; set; }
    public string? LowActUrl { get; set; }
}