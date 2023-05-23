using Leader.Domain.Entity;

namespace Leader.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> FindByEmail(string email, CancellationToken ct);
    Task<User> FindByMobilePhone(string mobilePhone, CancellationToken ct);
}