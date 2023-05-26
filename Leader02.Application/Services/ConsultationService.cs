using Leader.Domain.Entity;
using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Leader02.Application.Mappers;

namespace Leader02.Application.Services;

public class ConsultationService : IConsultationService
{
    private readonly IUserRepository _userRepository;
    private readonly IConsultationRepository _consultationRepository;

    public ConsultationService(IUserRepository userRepository, IConsultationRepository consultationRepository)
    {
        _userRepository = userRepository;
        _consultationRepository = consultationRepository;
    }

    public async Task<ConsultationDto?> CreateConsultation(string? topic, long userId, Guid consultationSlotId, CancellationToken ct)
    {
        var user = await _userRepository.GetById(userId, ct);
        if (user == null)
            return null;
        
        var consultation = new Consultation
        {
            Topic = topic,
            User = user,
            ConsultationSlotId = consultationSlotId
        };

        var savedConsultation = await _consultationRepository.AddAsync(consultation, ct);
        return savedConsultation.ConsultationToConsultationDto();
    }
}