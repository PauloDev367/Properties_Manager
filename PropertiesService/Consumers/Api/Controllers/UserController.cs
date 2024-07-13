using Application;
using Application.DTO.Request.Auth;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly Domain.Ports.ILogger _logger;
    public UserController(IAuthenticationService authenticationService, Domain.Ports.ILogger logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUserDto createUserDto)
    {
        var data = await _authenticationService.RegisterAsync(createUserDto);
       if(data.Errors.Count > 0)
        {
            _logger.LogInfo("Error when try to create new user: " + createUserDto.ToString());
            return BadRequest(data);
        }
        
        _logger.LogInfo("New user was created: " + createUserDto.ToString());
        var uri = "api/v1/users/" + data.User.Id;
        return Created(uri, data);
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto request)
    {
        var data = await _authenticationService.AuthenticateAsync(request);
        _logger.LogInfo($"User token generated: {request.Email}");
        return Ok(data);
    }
}
