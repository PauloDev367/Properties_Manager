using Application.DTO.Request.Auth;
using Application.DTO.Response.Auth;
using Domain.Ports.DTO.Response;

namespace Application;

public interface IAuthenticationService
{
    public Task<ICreatedUserDto> RegisterAsync(CreateUserDto register);
    public Task<UserLoginResponseDto> AuthenticateAsync(UserLoginRequestDto request);
}
