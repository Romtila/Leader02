using Leader02.Application.RequestModels.Auth;
using Leader02.Application.ResponseModels.Auth;

namespace Leader02.Application.IServices;

public interface IAuthService
{
    Task<AuthenticationUserResponse?> Authenticate(UserLoginRequest model, CancellationToken ct);
}