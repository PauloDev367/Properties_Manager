using Application;
using Application.DTO.Request.Auth;
using Application.DTO.Request.User;
using Application.User.Ports;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly Domain.Ports.ILogger _logger;
    private readonly IUserService _userService;
    public UserController(IAuthenticationService authenticationService, Domain.Ports.ILogger logger, IUserService userService)
    {
        _authenticationService = authenticationService;
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUserDto createUserDto)
    {
        var data = await _authenticationService.RegisterAsync(createUserDto);
        if (data.Errors.Count > 0)
        {
            _logger.LogInfo("Error when try to create new user: " + createUserDto.ToString());
            return BadRequest(data);
        }

        _logger.LogInfo("New user was created: " + createUserDto.ToString());
        var uri = "api/v1/users/" + data.User.Id;
        return Created(uri, data);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetUserParamsRequestDto request)
    {
        var data = await _userService.GetAllAsync(request);
        return Ok(data);
    }
    [HttpGet("id:guid")]
    public async Task<IActionResult> GetOneAsync(Guid id)
    {
        var data = await _userService.GetOneAsync(id);
        return Ok(data);
    }
}
