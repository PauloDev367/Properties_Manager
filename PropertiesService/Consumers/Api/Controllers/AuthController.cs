using Application;
using Application.DTO.Request.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly Domain.Ports.ILogger _logger;
    public AuthController(IAuthenticationService authenticationService, Domain.Ports.ILogger logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto request)
    {
        var data = await _authenticationService.AuthenticateAsync(request);
        _logger.LogInfo($"User token generated: {request.Email}");
        return Ok(data);
    }
}
