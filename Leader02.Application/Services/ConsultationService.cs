using Leader.Domain.Entity;
using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Leader02.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Leader02.Application.Services;

public class ConsultationService : IConsultationService
{
    private readonly IUserRepository _userRepository;
    private readonly IConsultationRepository _consultationRepository;

    public ConsultationService(IServiceScopeFactory serviceScopeFactory)
    {
        _userRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IUserRepository>();
        _consultationRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IConsultationRepository>();
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

        var isSaved = await _consultationRepository.AddAsync(consultation, ct);

        if (isSaved)
        {
            var savedConsultation = await _consultationRepository.GetByConsultationSlotId(consultationSlotId, ct);
            return savedConsultation?.ConsultationToConsultationDto();
        }
        
        return null;
    }
}