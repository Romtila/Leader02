namespace Leader02.Application.RequestModels.ConsultationSlot;

public class CancelSlotBookingByUserRequest
{
    public Guid SlotId { get; set; }
    public long UserId { get; set; }
}