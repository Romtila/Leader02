using Leader.Domain.Entity;
using Leader.Domain.Interfaces;

namespace Leader02.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(Leader02Context dbContext) : base(dbContext)
    {
    }

    public Task<User> FindByEmail(string email, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByMobilePhone(string mobilePhone, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}