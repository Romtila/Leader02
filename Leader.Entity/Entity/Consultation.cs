namespace Leader.Domain.Entity;

public class Consultation
{
    public Guid Id { get; set; }
    public string? Topic { get; set; }
    public DateTime? StarDateTime { get; set; }
    public DateTime? FinishDateTime { get; set; }
    public string? VideoRecordPath { get; set; }
    public string? OtherInformation { get; set; }

    public long? UserId { get; set; }
    public User? User { get; set; } = new();

    public long? DepartmentUserId { get; set; }
    public DepartmentUser? DepartmentUser { get; set; } = new();

    public int? ConsultationSlotId { get; set; }
    public ConsultationSlot? ConsultationSlot { get; set; } = new();
}