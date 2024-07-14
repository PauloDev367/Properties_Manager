using Application.DTO.Request.Auth;
using Application.DTO.Request.User;
using Application.DTO.Response.Auth;
using Application.DTO.Response.User;
namespace Application.User.Ports;

public interface IUserService
{
    public Task<CreatedUserDto> CreateAsync(CreateUserDto request, string passwordHash);
    public Task<UserPaginationResponseDto> GetAllAsync(GetUserParamsRequestDto request);
    public Task<BasicUserInfoResponseDto?> GetOneAsync(Guid id);
    public Task DeleteAsync(Guid id);
}
