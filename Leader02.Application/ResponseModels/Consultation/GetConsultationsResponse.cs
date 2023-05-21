using Leader02.Application.DtoModels;

namespace Leader02.Application.ResponseModels.Consultation;

public class GetConsultationsResponse
{
    public List<ConsultationDto> Consultations { get; set; } = new();
}