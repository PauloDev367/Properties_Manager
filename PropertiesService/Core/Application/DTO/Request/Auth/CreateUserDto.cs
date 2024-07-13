using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request.Auth;

public class CreateUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    [MinLength(3)]
    public string Nickname { get; set; }
    public override string ToString()
    {
        return $"{Name} - {Nickname} - {Email} - {Password}";
    }
}
