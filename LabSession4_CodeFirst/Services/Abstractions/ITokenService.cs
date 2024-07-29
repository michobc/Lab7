using LabSession4_CodeFirst.Settings;

namespace LabSession4_CodeFirst.Services.Abstractions;

public interface ITokenService
{
    public string GenerateJwt(JwtSettings jwtSettings, string[] permissions);
}