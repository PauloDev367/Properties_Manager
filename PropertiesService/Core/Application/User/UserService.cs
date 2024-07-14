using Application.DTO.Request.Auth;
using Application.DTO.Request.User;
using Application.DTO.Response.Auth;
using Application.DTO.Response.User;
using Application.User.Ports;
using Domain.Entities;
using Domain.Ports;

namespace Application.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreatedUserDto> CreateAsync(CreateUserDto request, string passwordHash)
    {
        var user = new Domain.Entities.User
        {
            Email = request.Email,
            Name = request.Name,
            Nickname = request.Nickname,
            Password = passwordHash
        };

        var response = await _userRepository.CreateAsync(user);
        return new CreatedUserDto().FromUser(response);
    }

    public async Task<List<BasicUserInfoResponseDto>> GetAllAsync(GetUserParamsRequestDto request)
    {
        string[] orderParams = !string.IsNullOrEmpty(request.OrderBy) ? request.OrderBy.ToString().Split(",") : "id,desc".Split(",");
        var orderBy = orderParams[0];
        var order = orderParams[1];

        var data = await _userRepository.GetAllAsync(request.PerPage, request.Page, orderBy, order);
        var response = data.Select(u => new BasicUserInfoResponseDto(u)).ToList();
        return response;
    }
}
