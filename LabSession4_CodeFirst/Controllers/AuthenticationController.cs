using LabSession4_CodeFirst.Models;
using LabSession4_CodeFirst.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LabSession4_CodeFirst.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IKeycloakAuthService keycloakAuthService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> login([FromBody] LoginDto request)
    {
        var auth = await keycloakAuthService.AuthenticateAsync(request);
        return Ok(auth);
    }
}