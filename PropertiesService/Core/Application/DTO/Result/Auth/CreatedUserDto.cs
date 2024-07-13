using Domain.Ports.DTO.Result;

namespace Application.DTO.Result.Auth;

public class CreatedUserDto : ICreatedUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICreatedUserDto FromUser(Domain.Entities.User user)
    {
        return new CreatedUserDto
        {
            Email = user.Email,
            Name = user.Name,
            Nickname = user.Nickname,
            Id = user.Id,
            CreatedAt = user.CreatedAt,
        };
    }
}
