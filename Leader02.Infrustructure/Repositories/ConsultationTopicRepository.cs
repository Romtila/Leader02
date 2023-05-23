using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class ConsultationTopicRepository : BaseRepository<ConsultationTopic>, IConsultationTopicRepository
{
    public ConsultationTopicRepository(Leader02Context dbContext) : base(dbContext)
    {
    }
}