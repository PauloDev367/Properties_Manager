using Application.DTO.Request.Auth;
using Application.DTO.Response.Auth;


namespace Application;

public interface IAuthenticationService
{
    public Task<CreatedUserDto> RegisterAsync(CreateUserDto register);
    public Task<UserLoginResponseDto> AuthenticateAsync(UserLoginRequestDto request);
}
