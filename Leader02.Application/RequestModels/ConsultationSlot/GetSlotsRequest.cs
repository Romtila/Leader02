namespace Leader02.Application.RequestModels.ConsultationSlot;

public class GetSlotsRequest
{
    public DateTime? SlotDate { get; set; }
    public int? SubDepartmentId { get; set; }
}