using Application.DTO.Request.Auth;
using Application.DTO.Result.Auth;
using Domain.Entities;
using Domain.Ports.DTO.Result;

namespace Application;

public interface IAuthenticationService
{
    public Task<ICreatedUserDto> RegisterAsync(CreateUserDto register);
    public Task<object> AuthenticateAsync(string username, string password);
}
