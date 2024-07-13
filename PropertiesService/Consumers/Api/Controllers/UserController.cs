using Application;
using Application.DTO.Request.Auth;
using Application.DTO.Response.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public UserController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUserDto createUserDto)
    {
        var data = await _authenticationService.RegisterAsync(createUserDto);
        return Ok(data);
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto request) {

        var data = await _authenticationService.AuthenticateAsync(request);
        return Ok(data);
    }
}
