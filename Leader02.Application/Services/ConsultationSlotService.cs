using Leader.Domain.Enums;
using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Leader02.Application.Mappers;

namespace Leader02.Application.Services;

public class ConsultationSlotService : IConsultationSlotService
{
    private readonly IConsultationSlotRepository _consultationSlotRepository;

    public ConsultationSlotService(IConsultationSlotRepository consultationSlotRepository)
    {
        _consultationSlotRepository = consultationSlotRepository;
    }

    public async Task<List<ConsultationSlotDto>> GetAllBySubDepartmentId(int subDepartmentId, CancellationToken ct)
    {
        var consultationSlots = await _consultationSlotRepository.GetAllBySubDepartmentId(subDepartmentId, ct);
        return consultationSlots.ConsultationSlotsToConsultationSlotsDto();
    }

    public async Task<ConsultationSlotDto?> UpdateState(Guid id, ConsultationSlotStatus status, CancellationToken ct)
    {
        var consultationSlot = await _consultationSlotRepository.GetById(id, ct);
        if (consultationSlot != null)
        {
            consultationSlot.Status = status;
            var updatedConsultationSlot = await _consultationSlotRepository.UpdateAsync(consultationSlot, ct);
            return updatedConsultationSlot.ConsultationSlotToConsultationSlotDto();
        }

        return null;
    }
}