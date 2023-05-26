using Leader.Domain.Interfaces;
using Leader02.Application.DtoModels;
using Leader02.Application.IServices;
using Leader02.Application.Mappers;

namespace Leader02.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetById(long id, CancellationToken ct)
    {
        var user = await _userRepository.GetById(id, ct);
        return user?.UserToUserDto();
    }
}