using System.Security.Cryptography;
using System.Text;
using Leader.Domain.Interfaces;
using Leader02.Application.IServices;
using Leader02.Application.Jwt;
using Leader02.Application.RequestModels.Auth;
using Leader02.Application.ResponseModels.Auth;

namespace Leader02.Application.Services;

public class AuthService : IAuthService
{
    private readonly IJwtUtils _jwtUtils;
    private readonly IUserRepository _userRepository;
    private readonly IDepartmentUserRepository _departmentUserRepository;

    public AuthService(IUserRepository userRepository, IDepartmentUserRepository departmentUserRepository, IJwtUtils jwtUtils)
    {
        _userRepository = userRepository;
        _departmentUserRepository = departmentUserRepository;
        _jwtUtils = jwtUtils;
    }

    [Obsolete("Obsolete")]
    public async Task<AuthenticationUserResponse?> Authenticate(UserLoginRequest model, CancellationToken ct)
    {
        if (model.UserType == 0)
        {
            var user = await _userRepository.GetByEmailAndPassword(model.Email, Encrypt(model.Password), ct);
            if (user == null)
                return new AuthenticationUserResponse
                {
                    IsAuthenticated = false,
                    Message = $"No Accounts Registered with {model.Email}."
                };
            
            var userToken = _jwtUtils.GenerateUserJwtToken(user);

            return new AuthenticationUserResponse
            {
                Email = user.Email,
                Role = "User",
                Token = userToken,
                IsAuthenticated = true,
                Message = "Get token"
            };
        }

        var departmentUser = await _departmentUserRepository.GetByEmailAndPassword(model.Email, Encrypt(model.Password), ct);
        if (departmentUser == null)
            return new AuthenticationUserResponse
            {
                IsAuthenticated = false,
                Message = $"No Accounts Registered with {model.Email}."
            };
            
        var departmentUserToken = _jwtUtils.GenerateDepartmentUserJwtToken(departmentUser);

        return new AuthenticationUserResponse
        {
            Email = departmentUser.Email,
            Role = "DepartmentUser",
            Token = departmentUserToken,
            IsAuthenticated = true,
            Message = "Get token"
        };
    }
    

    [Obsolete("Obsolete")]
    private string Encrypt(string str)
    {
        var EncrptKey = "";
        byte[] iv = {18, 52, 86, 120, 144, 171, 205, 239};
        var byKey = Encoding.UTF8.GetBytes(EncrptKey[..8]);
        var des = new DESCryptoServiceProvider();
        var inputByteArray = Encoding.UTF8.GetBytes(str);
        var ms = new MemoryStream();
        var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, iv), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Convert.ToBase64String(ms.ToArray());
    }

    [Obsolete("Obsolete")]
    private string Decrypt(string str)
    {
        str = str.Replace(" ", "+");
        var DecryptKey = "2013;[pnuLIT)WebCodeExpert";
        byte[] iv = {18, 52, 86, 120, 144, 171, 205, 239};

        var byKey = Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
        var des = new DESCryptoServiceProvider();
        var inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
        var ms = new MemoryStream();
        var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        var encoding = Encoding.UTF8;
        return encoding.GetString(ms.ToArray());
    }
}