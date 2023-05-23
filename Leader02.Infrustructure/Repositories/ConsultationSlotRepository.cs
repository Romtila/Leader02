using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class ConsultationSlotRepository : BaseRepository<ConsultationSlot>, IConsultationSlotRepository
{
    public ConsultationSlotRepository(Leader02Context dbContext) : base(dbContext)
    {
    }
}