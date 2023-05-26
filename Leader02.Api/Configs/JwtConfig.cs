using Leader02.Application.Jwt;

namespace Leader02.Api.Configs;

public class JwtConfig : IJwtConfig
{
    public string SecretJwtKet { get; set; } = string.Empty;
    
    public static JwtConfig Create(IConfigurationRoot configurationRoot)
    {
        return configurationRoot.GetSection("AppSettings:SecretJwtKet").Get<JwtConfig>() ?? new JwtConfig();
    }
}