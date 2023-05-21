using Leader02.Application.DtoModels;

namespace Leader02.Application.ResponseModels.ConsultationSlot;

public class GetSlotsResponse
{
    public List<ConsultationSlotDto> ConsultationSlots { get; set; } = new();
}