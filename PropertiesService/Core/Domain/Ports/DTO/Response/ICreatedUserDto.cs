using Domain.Entities;

namespace Domain.Ports.DTO.Response;

public interface ICreatedUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public ICreatedUserDto FromUser(User user);
}
