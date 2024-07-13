using Application.DTO.Request.Auth;
using Application.DTO.Response.Auth;
namespace Application.User.Ports;

public interface IUserService
{
    public Task<CreatedUserDto> CreateAsync(CreateUserDto request, string passwordHash);
}
