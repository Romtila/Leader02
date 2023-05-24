namespace Leader.Domain.Entity;

public class RequirementBasicRequirement
{
    public long Id { get; set; }
    public string? BasicRequirement { get; set; }

    public Requirement Requirement { get; set; } = new();
}