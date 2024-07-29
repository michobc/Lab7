using LabSession4_CodeFirst.Models;

namespace LabSession4_CodeFirst.Services.Abstractions;

public interface IKeycloakAuthService
{
    public Task<string> AuthenticateAsync(LoginDto request);
}