
namespace Application.DTO.Response.Auth;

public class CreatedUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public DateTime CreatedAt { get; set; }
    public CreatedUserDto FromUser(Domain.Entities.User user)
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
