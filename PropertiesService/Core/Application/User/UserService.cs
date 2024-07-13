using Application.DTO.Request.Auth;
using Application.DTO.Response.Auth;
using Application.User.Ports;
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
}
