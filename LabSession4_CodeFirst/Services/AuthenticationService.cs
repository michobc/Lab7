using LabSession4_CodeFirst.Services.Abstractions;
using LabSession4_CodeFirst.Settings;

namespace LabSession4_CodeFirst.Services;

public class AuthenticationService(ITokenService tokenService, JwtSettings jwtSettings) : IAuthenticationService
{
    public string Login(string username, string password)
    {
        //if user exist return token
        return tokenService.GenerateJwt(jwtSettings, ["SuperAdmin"]);
    }
}