using Domain.Entities;
using Domain.Ports.DTO.Response;

namespace Domain.Ports.DTO.Request;

public interface ICreateUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
}
