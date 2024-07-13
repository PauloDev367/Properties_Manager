using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request.Auth;

public class UserLoginRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

}
